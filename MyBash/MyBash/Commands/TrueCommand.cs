namespace MyBash.Commands
{
	public class TrueCommand : Command
	{
		public TrueCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute) : base(bash, arguments, canExecute) { }
		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				_bash.LastOutputStatus = MyBash.True;
			}
		}
	}
}