using ListManMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListManMobile.ViewModels
{
	public class TaskVM : INotifyPropertyChanged
	{
		public TaskVM()
		{
			_task = new TaskModel();
		}
		public TaskVM(TaskModel task, CategoryVM taskList)
		{
			_task = task;
			_taskList = taskList;
		}

		private TaskModel _task;
		private CategoryVM _taskList;

		public CategoryVM TaskList
		{
			get { return _taskList; }
			set
			{
				_taskList = value;
				OnPropertyChanged("ListViewModel");
			}
		}
		public TaskModel Task
		{ 
			get { return _task; }
			private set { _task = value; }
		}
		public string Name
		{
			get { return _task.Name; }
			set
			{
				_task.Name = value;
				OnPropertyChanged("Name");
			}
		}
		public DateTime Date
		{
			get { return _task.Date; }
			set
			{
				_task.Date = value;
				OnPropertyChanged("Date");
			}
		}
		public bool IsCompleted
		{
			get { return _task.IsCompleted; }
			set
			{
				_task.IsCompleted = value;
				OnPropertyChanged("IsCompleted");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
