using static System.Console;

namespace MyBash
{
	public class Program
	{
		public static void Main(string[] args)
		{
			char a = (char)Read();
			var b = ReadLine();
			Write(a+b);
		}
	}
}