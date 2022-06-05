using MyBash.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBash
{
	public class MyBash
	{
		public const int True = 0;
		public const int False = 1;
		private string _path;
		private bool _isWorking;
		
		public bool IsWorking{ get => _isWorking; set => _isWorking = value; }
		public string Path { get => _path; set => _path = value; }
		public Dictionary<string, List<string>> Variables;
		public Queue<List<string>> Commands;
		public int LastOutputStatus { get; set; }
		public MyBash()
		{
			_path = "C:";
			Variables = new Dictionary<string, List<string>>();
			Commands = new Queue<List<string>>();
			LastOutputStatus = True;
			_isWorking = true;
		}
		public void RunBash()
		{
			Console.WriteLine("Приложение MyBash начало работу");
			while (_isWorking)
			{
				Console.Write($"[MyBash {_path}]");
				Reader reader = new Reader(this, Console.ReadLine());
				reader.ReadAndParse();
				AnalyserAndExecutor executeAll = new AnalyserAndExecutor(this);
				executeAll.ExecuteString();
			}
			Console.WriteLine("Приложение MyBash завершило работу");
		}

		public void RunScript(string path)
		{
			using (StreamReader fileReader = new StreamReader(path))
			{
				foreach (var commandLine in fileReader.ReadToEnd().Split('\n'))
				{
					if (commandLine == String.Empty)
					{
						break;
					}
					Reader reader = new Reader(this, commandLine);
					reader.ReadAndParse();
					AnalyserAndExecutor executeAll = new AnalyserAndExecutor(this);
					executeAll.ExecuteString();
				}
			}
		}

	}
}