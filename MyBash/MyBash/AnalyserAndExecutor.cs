using MyBash.Commands;
using System.Diagnostics.Tracing;

namespace MyBash
{
	public class AnalyserAndExecutor
	{
		private MyBash _bash;

		public AnalyserAndExecutor(MyBash bash)
		{
			_bash = bash;
		}

		private IBashCommand Analyse(List<string> analysedString)
		{
			bool append = true;
			string? path = null;
			Predicate<int> canExecute = (_) => true;
			if (analysedString[0] == "&&")
			{
				canExecute = (lastStatus) => lastStatus == 0;
				analysedString.RemoveAt(0);
			}
			else if (analysedString[0] == "||")
			{
				canExecute = (lastStatus) => lastStatus != 0;
				analysedString.RemoveAt(0);
			}

			int index = analysedString.FindIndex((word) => word[0] == '$' && word[^1] != '=' && word != "$?");
			while (index != -1)
			{
				var variableName = analysedString[index].Substring(1);
				analysedString.RemoveAt(index);
				if (_bash.Variables.ContainsKey(variableName))
				{
					analysedString.InsertRange(index, _bash.Variables[variableName]);
				}
				else
				{
					return new ErrorCommand(_bash, $"MyBash: Переменная {variableName} не найдена");
				}
				index = analysedString.FindIndex((word) => word[0] == '$' && word[^1] != '=');
			}
			
			string commandName = analysedString[0];
			analysedString.RemoveAt(0);
			
			if (commandName[0] == '$' && commandName.Length > 2 && commandName[^1] == '=')
			{
				return new NewVarCommand(_bash, analysedString, canExecute, commandName.Substring(1, commandName.Length - 2));
			}
			if (analysedString.Count >= 2)
			{
				if (analysedString[^2] == ">")
				{
					append = false;
					path = analysedString[^1];
					analysedString.RemoveAt(analysedString.Count - 1);
					analysedString.RemoveAt(analysedString.Count - 1);
				}
				else if (analysedString[^2] == ">>")
				{
					append = true;
					path = analysedString[^1];
					analysedString.RemoveAt(analysedString.Count - 1);
					analysedString.RemoveAt(analysedString.Count - 1);
				}
			}

			if (analysedString.Count > 0 && analysedString[0] == "<" )
			{
				string inputPath;
				if (File.Exists(_bash.Path + '\\' + analysedString[1]))
				{
					inputPath = _bash.Path + '\\' + analysedString[1];
				}
				else if (File.Exists(analysedString[1]))
				{
					inputPath = analysedString[1];
				}
				else
				{
					return new ErrorCommand(_bash, $"MyBash: Файл {analysedString[1]} не найден");;
				}
				analysedString = new List<string>(File.ReadAllText(inputPath).Split(' '));
			}
			
			switch (commandName)
			{
				case "echo": return new EchoCommand(_bash, analysedString, canExecute, append, path);
				case "cat": return new CatCommand(_bash, analysedString, canExecute, append, path);
				case "wc": return new WcCommand(_bash, analysedString, canExecute, append, path);
				case "pwd": return new PwdCommand(_bash, analysedString, canExecute, append, path);
				case "cd": return new CdCommand(_bash, analysedString, canExecute);
				case "true": return new TrueCommand(_bash, analysedString, canExecute);
				case "false": return new FalseCommand(_bash, analysedString, canExecute);
				case "$?": return new LastStatusCommand(_bash, analysedString, canExecute);
				case "script": return new ScriptCommand(_bash, analysedString[0], canExecute);
				case "exit": return new ExitCommand(_bash);
				default: return new ErrorCommand(_bash, $"MyBash: команда {commandName} не существует");
			}
		}

		public void ExecuteString()
		{
			while (_bash.Commands.Count > 0)
			{
				IBashCommand command = Analyse(_bash.Commands.Dequeue());
				command.Execute();
			}
		}
	}
}