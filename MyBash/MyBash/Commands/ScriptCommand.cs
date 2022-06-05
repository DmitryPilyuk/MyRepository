namespace MyBash.Commands
{
	public class ScriptCommand : IBashCommand
	{
		private MyBash _bash;
		private string _argument;
		Predicate<int> _canExecute;

		public ScriptCommand(MyBash bash, string arg, Predicate<int> canExecute)
		{
			_bash = bash;
			_argument = arg;
			_canExecute = canExecute;
		}
		public void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
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
				_bash.LastOutputStatus = MyBash.True;
				_bash.RunScript(path);
			}
		}
	}
}