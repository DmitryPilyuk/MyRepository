namespace MyBash.Commands
{
	public class CatCommand : Command
	{
		public CatCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute, bool append = true,
			string? path = null) : base(bash, arguments, canExecute, append, path) { }
		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				if (_arguments.Count == 0)
				{
					_bash.LastOutputStatus = MyBash.False;
					_output = "cat: Аргументы не переданы";
					WriteError();
					return;
				}
				string[] output = new string[_arguments.Count];
				int i = 0;
				foreach (var arg in _arguments)
				{
					string path;
					
					if (File.Exists($"{_bash.Path}\\{arg}"))
					{
						path = $"{_bash.Path}\\{arg}";
					}
					else if (File.Exists(arg))
					{
						path = arg;
					}
					else
					{
						_bash.LastOutputStatus = MyBash.False;
						_output = $"cat: Файл {arg.Substring(arg.LastIndexOf('\\')+1)} не найден";
						WriteError();
						return;
					}
					output[i] = File.ReadAllText(path) + '\n';
					i++;
				}
				_output = String.Concat(output);
				_bash.LastOutputStatus = MyBash.True; 
				WriteResult();
			}
		}
	}
}