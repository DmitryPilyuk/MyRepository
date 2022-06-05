using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBash.Commands
{
	public class PwdCommand : Command
	{
		public PwdCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute, bool append = true,
			string? path = null) : base(bash, arguments, canExecute, append, path) { }
		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				_bash.LastOutputStatus = MyBash.True;
				StringBuilder sb = new StringBuilder($"{_bash.Path}\n");
				foreach (var fileName in Directory.GetFiles(_bash.Path))
				{
					sb.Append($"{fileName.Substring(fileName.LastIndexOf('\\') + 1)}\n");
				}
				_output = sb.ToString();
				WriteResult();
			}
		}
	}
}
