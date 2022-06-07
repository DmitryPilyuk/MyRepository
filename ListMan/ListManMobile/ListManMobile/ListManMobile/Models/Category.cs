using ListManMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListManMobile.Models
{
	public class Category
	{
		private string _categoryName;
		public string CategoryName
		{
			get { return _categoryName; }
			set { _categoryName = value; }
		}

		private List<TaskModel> _tasks;
		public List<TaskModel> Tasks 
		{
			get { return _tasks; }
			set { _tasks = value; }
		}
		public Category() { }
		public Category(CategoryVM categoryVM)
		{
			_categoryName = categoryVM.CategoryName;
			_tasks = new List<TaskModel>();
			foreach(var task in categoryVM.TaskList)
			{
				_tasks.Add(task.Task);
			}
		}
	}
}
