namespace MyBash.Commands
{
	public class LastStatusCommand : Command
	{
		public LastStatusCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute) : base(bash, arguments, canExecute) { }
		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				if (_bash.LastOutputStatus == 0)
				{
					_output = "true";
					Console.WriteLine(_output);
				}
				else
				{
					_output = "false";
					Console.WriteLine(_output);
				}
			}
		}
	}
}