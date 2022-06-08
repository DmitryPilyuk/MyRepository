using ListManLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManConsole
{
	public class Commands
	{
		private ConsoleLogic _logic;

		public Commands(ConsoleLogic logic)
		{
			_logic = logic;
		}

		public void Save()
		{
			SaverAndLoader saver = new SaverAndLoader();
			saver.Save(_logic.Categories);
		}
		public void NewList()
		{
			_logic.Categories = new CategoryList();
			_logic.CurrentCategory = null;
		}
		public void ShowList()
		{
			if (_logic.CurrentCategory != null)
			{
				int i = 1;
				Console.WriteLine($"Список задач в {_logic.CurrentCategory.CategoryName}");
				foreach(var task in _logic.CurrentCategory.TaskList)
				{
					Console.WriteLine($"{i}. {task.Date.Day}.{task.Date.Month}.{task.Date.Year} {task.Name} {task.IsCompleted}");
					i++;
				}
			}
			else
			{
				Console.WriteLine("Список категорий");
				int i = 1;
				foreach(var category in _logic.Categories.Categories)
				{
					Console.WriteLine($"{i}. {category.CategoryName}");
					i++;
				}
			}
		}
		public void SwitchTo(string[] args)
		{
			if (args.Length !=1)
			{
				Console.WriteLine("Неверный аргумент");
				return;
			}
			try
			{
				int i = Convert.ToInt32(args[0]) - 1;
				if (_logic.CurrentCategory == null)
				{
					if (i < 0|| i >= _logic.Categories.Categories.Count)
					{
						Console.WriteLine("Неверный индекс");
					}
					else
					{
						_logic.CurrentCategory = _logic.Categories.Categories[i];
						ShowList();
					}
				}
				else
				{
					Console.WriteLine("Категория уже выбрана, вернитесь к списку категорий");
				}
			}
			catch
			{
				Console.WriteLine("Неверный аргумент");
			}
		}
		public void Back()
		{
			_logic.CurrentCategory = null;
		}
		public void Delete(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("Неверный аргумент");
				return;
			}
			try
			{
				int i = Convert.ToInt32(args[0]) - 1;
				if (_logic.CurrentCategory == null)
				{
					if (i < 0|| i >= _logic.Categories.Categories.Count)
					{
						Console.WriteLine("Неверный индекс");
					}
					else
					{
						_logic.Categories.DelCategory(_logic.Categories.Categories[i]);
						ShowList();
					}
				}
				else
				{
					if (i < 0|| i >= _logic.Categories.Categories.Count)
					{
						Console.WriteLine("Неверный индекс");
					}
					else
					{
						_logic.CurrentCategory.TaskList.Remove(_logic.CurrentCategory.TaskList[i]);
						ShowList();
					}
				}
			}
			catch
			{
				Console.WriteLine("Неверный аргумент");
			}
			
		}
		public void Add(string[] args)
		{
			if (_logic.CurrentCategory == null)
			{
				if (args.Length == 0)
				{
					Console.WriteLine("Имя категории не может быть пустым");
				}
				else
				{
					_logic.Categories.AddCategory(string.Join(" ", args));
					ShowList();
				}
			}
			else
			{
				if (args.Length < 2)
				{
					Console.WriteLine("Не достаточно аргументов");
				}
				else
				{
					try
					{
						int[] dateArr = new int[3];
						int i = 0;
						foreach (var n in args[0].Split('.'))
						{
							dateArr[i] = Convert.ToInt32(n);
							i++;
						}
						DateTime date = new DateTime(dateArr[2], dateArr[1], dateArr[0]);
						_logic.CurrentCategory.AddTask(string.Join(' ', args.Skip(1)), date);
						ShowList();
					}
					catch
					{
						Console.WriteLine("Неверная дата");
					}
				}
			}
		}
		public void ChangeStatus(string[] args)
		{
			if (args.Length !=1)
			{
				Console.WriteLine("Неверный аргумент");
				return;
			}
			try
			{
				int i = Convert.ToInt32(args[0]) - 1;
				if (_logic.CurrentCategory != null)
				{
					if (i < 0 || i >= _logic.Categories.Categories.Count)
					{
						Console.WriteLine("Неверный индекс");
					}
					else
					{
						_logic.CurrentCategory.TaskList[i].IsCompleted = !_logic.CurrentCategory.TaskList[i].IsCompleted;
					}
					ShowList();
				}
				else
				{
					Console.WriteLine("Категория не выбрана");
				}
			}
			catch
			{
				Console.WriteLine("Неверный аргумент");
			}
			
		}
	}
}
