namespace MyBash.Commands
{
	public class ScriptCommand : IBashCommand
	{
		private MyBash _bash;
		private string _argument;

		public ScriptCommand(MyBash bash, string arg)
		{
			_bash = bash;
			_argument = arg;
		}
		public void Execute()
		{
			string path;
					
			if (File.Exists($"{_bash.Path}\\{_argument}"))
			{
				path = $"{_bash.Path}\\{_argument}";
			}
			else if (File.Exists(_argument))
			{
				path = _argument;
			}
			else
			{
				_bash.LastOutputStatus = MyBash.False;
				Console.WriteLine($"MyBash: script: Файл {_argument} не найден");
				return;
			}
			_bash.RunScript(path);
		}
	}
}