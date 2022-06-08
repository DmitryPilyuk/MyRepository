namespace ListManConsole
{
	class Programm
	{
		static void Main(string[] args)
		{
			ConsoleLogic consoleLogic = new ConsoleLogic();
			while (true)
			{
				consoleLogic.Execute(Console.ReadLine().Trim());
			}
		}
	}
}