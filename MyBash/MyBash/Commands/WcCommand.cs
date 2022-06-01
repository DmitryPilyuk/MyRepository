namespace MyBash.Commands
{
	public class WcCommand : Command
	{

		public WcCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute, bool append = true,
			string? path = null) : base(bash, arguments, canExecute, append, path)
		{
		}
		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				if (_arguments.Count == 0)
				{
					_bash.LastOutputStatus = MyBash.False;
					Console.WriteLine("MyBash: wc: Аргументы не переданы \n");
					return;
				}
				long totalWords = 0;
				long totalLines = 0;
				long totalBytes = 0;
				string[] output = new string[_arguments.Count + 1];
				int i = 0;
				foreach (var arg in _arguments)
				{
					string path;
					if (File.Exists(arg))
					{
						path = arg;
					}
					else if (File.Exists(_bash.Path + '/' + arg))
					{
						path = _bash.Path + '/' + arg;
					}
					else
					{
						_bash.LastOutputStatus = MyBash.False;
						Console.WriteLine($"MyBash: wc: Файл {arg} не найден");
						return;
					}
					long words = 0;
					string text = File.ReadAllText(path);
					string[] lines = text.Split('\n');
					foreach (var line in lines)
					{
						if (line != String.Empty)
						{
							words += line.Split().Length;
						}
					}
					totalWords += totalWords;
					totalLines += lines.Length - 1;
					totalBytes += File.ReadAllBytes(path).Length;
					output[i] =
						$"{lines.Length - 1} {words} {File.ReadAllBytes(path).Length} {path.Substring(path.LastIndexOf('\\') + 1)}\n";
					i++;
				}
				output[i] = $"{totalLines} {totalWords} {totalBytes} итого\n";
				_output = String.Concat(output);
				_bash.LastOutputStatus = MyBash.True;
				WriteResult();
			}
		}
	}
}