namespace MyBash.Commands
{
	public class ExitCommand : IBashCommand
	{
		private MyBash _bash;
		public ExitCommand(MyBash bash)
		{
			_bash = bash;
		}

		public void Execute()
		{
			_bash.IsWorking = false;
		}
	}
}