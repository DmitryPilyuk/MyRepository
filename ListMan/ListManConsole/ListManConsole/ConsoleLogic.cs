using ListManLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManConsole
{
	public class ConsoleLogic
	{
		private CategoryList _categories;
		public CategoryList Categories { get { return _categories; } set { _categories = value; } }
		private Category? _currentCategory;
		public Category? CurrentCategory { get { return _currentCategory; } set { _currentCategory = value; } }

		public ConsoleLogic()
		{
			SaverAndLoader loader = new SaverAndLoader();
			_categories = loader.Load();
			_currentCategory = null;
		}

		public void Execute(string input)
		{
			Commands commands = new Commands(this);
			string[] analysed = input.Trim().Split();
			switch (analysed[0])
			{
				case "Add":
					commands.Add(analysed.Skip(1).ToArray());
					break;
				case "Save":
					commands.Save();
					break;
				case "Back":
					commands.Back();
					break;
				case "NewList":
					commands.NewList();
					break;
				case "ShowList":
					commands.ShowList();
					break;
				case "SwitchTo":
					commands.SwitchTo(analysed.Skip(1).ToArray());
					break;
				case "ChangeStatus":
					commands.ChangeStatus(analysed.Skip(1).ToArray());
					break;
				case "Delete":
					commands.Delete(analysed.Skip(1).ToArray());
					break;
				default:
					Console.WriteLine("Неверная команда");
					break;
			}
		}
	}
}
