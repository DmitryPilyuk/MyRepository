namespace MyBash.Commands
{
	public class NewVarCommand : IBashCommand
	{
		private MyBash _bash;
		private List<string> _arguments;
		private string _name;

		public NewVarCommand(MyBash bash, string name, List<string> arguments)
		{
			_bash = bash;
			_name = name;
			_arguments = arguments;
		}

		public void Execute()
		{
			_bash.Variables.Add(_name, _arguments);
			_bash.LastOutputStatus = MyBash.True;
		}
	}
}