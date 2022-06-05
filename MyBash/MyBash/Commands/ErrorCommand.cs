namespace MyBash.Commands
{
	public class ErrorCommand : IBashCommand
	{
		private MyBash _bash;
		public string _errorMessage;
		public ErrorCommand(MyBash bash, string error)
		{
			_bash = bash;
			_errorMessage = error;
		}

		public void Execute()
		{
			_bash.LastOutputStatus = MyBash.False;
			Console.WriteLine(_errorMessage);
		}
	}
}