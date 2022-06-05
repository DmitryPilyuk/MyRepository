using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBash.Commands
{
	public class CdCommand : Command
	{
		public CdCommand(MyBash bash, List<string> arguments, Predicate<int> canExecute) : base(bash, arguments, canExecute) { }

		public override void Execute()
		{
			if (_canExecute(_bash.LastOutputStatus))
			{
				if (_arguments.Count > 1)
				{
					_bash.LastOutputStatus = MyBash.False;
					_output = "cd: Слишком много аргументов";
					WriteError();
					return;
				}
				else if (_arguments.Count == 0)
				{
					_bash.LastOutputStatus = MyBash.False;
					_output = "cd: Аргументы не переданы";
					WriteError();
					return;
				}
				if (Directory.Exists($"{_bash.Path}\\{_arguments[0]}"))
				{
					_bash.LastOutputStatus = MyBash.True;
					_bash.Path = $"{_bash.Path}\\{_arguments[0]}";
				}
				else if (Directory.Exists(_arguments[0]))
				{
					_bash.LastOutputStatus = MyBash.True;
					_bash.Path = _arguments[0];
				}
				else
				{
					_bash.LastOutputStatus = MyBash.False;
					_output = $"cd: {_arguments[0]}: Нет такого файла или каталога";
					WriteError();
				}
			}
		}
	
	}
}
