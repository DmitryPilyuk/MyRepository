namespace MyBash.Commands
{
	public class LastStatusCommand : IBashCommand
	{
		private MyBash _bash;
		public LastStatusCommand(MyBash bash)
		{
			_bash = bash;
		}
		public void Execute()
		{
			if (_bash.LastOutputStatus == 0)
			{
				Console.WriteLine("false");
			}
			else
			{
				Console.WriteLine("true");
			}
		}
	}
}