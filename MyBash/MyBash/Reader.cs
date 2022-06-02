using MyBash.Commands;

namespace MyBash
{ 
	internal class Reader
	{
		private readonly string _inputStr;
		private MyBash _bash;

		internal Reader(MyBash bash, string input)
		{
			_bash = bash;
			_inputStr = input;
		}

		internal void ReadAndParse()
		{
			List<string> command = new List<string>();
			string[] splited = _inputStr.Split();
			foreach (var word in splited)
			{
				if (word == ";")
				{
					_bash.Commands.Enqueue(command); 
					command = new List<string>();
				}
				else if (word == "&&")
				{
					_bash.Commands.Enqueue(command);
					command = new List<string>();
					command.Add("&&");
				}
				else if (word == "||")
				{
					_bash.Commands.Enqueue(command);
					command = new List<string>();
					command.Add("||");
				}
				else
				{
					if (word != String.Empty)
					{
						command.Add(word);
					}
				}
			}
			_bash.Commands.Enqueue(command);
		}
	}
}