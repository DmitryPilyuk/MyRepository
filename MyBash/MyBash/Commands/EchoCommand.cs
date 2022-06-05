namespace MyBash.Commands
{
	public class EchoCommand : Command
	{
		public EchoCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute, bool append = true,
			string? path = null) : base(bash, arguments, canExecute, append, path) { }
		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				_bash.LastOutputStatus = MyBash.True;
				_output = String.Join(" ", _arguments) + '\n';
				WriteResult();
			}
		}
	}
}