
namespace MyBash.Commands;

public abstract class Command : IBashCommand
{
	protected List<string> _arguments;
	protected string? _path;
	protected Predicate<int> _canExecute;
	protected string _output;
	protected MyBash _bash;
	protected bool _append;

	protected Command(MyBash bash, List<string> arguments, Predicate<int> canExecute, bool append = true, string? path = null)
	{
		_bash = bash;
		_arguments = arguments;
		_canExecute = canExecute;
		_path = path;
		_output = "";
		_append = append;
	}

	protected void WriteResult()
	{
		if (_path == null)
		{
			Console.Write(_output);
		}
		else
		{
			if (_path.Contains('\\'))
			{
				int i = _path.Length - 1;
				while (_path[i] != '\\')
				{
					i--;
				}
				string fileName = _path.Substring(i + 1);
				string path = _path.Substring(0, i);
				if (Directory.Exists(path))
				{
					using (StreamWriter writer = new StreamWriter(_path, _append))
					{
						writer.Write(_output);
					}
				}
				else
				{
					_output = "Файл для перенаправления вывода не найден";
					WriteError();
					_bash.LastOutputStatus = MyBash.False;
				}
				
			}
		}
	}
	protected void WriteError()
	{
		Console.WriteLine("MyBash: " + _output);
	}

	public abstract void Execute();
}