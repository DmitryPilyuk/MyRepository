namespace MyBash.Commands
{
	public class NewVarCommand : Command
	{
		private string _name;

		public NewVarCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute, string name) : base(bash, arguments, canExecute)
		{
			_name = name;
		}

		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				if (_arguments.Count == 0)
				{
					_bash.LastOutputStatus = MyBash.False;
					_output = $"В переменную {_name} не передано аргументов";
					WriteError();
					return;
				}
				_bash.Variables.Add(_name, _arguments);
				_bash.LastOutputStatus = MyBash.True;
			}
		}
	}
}