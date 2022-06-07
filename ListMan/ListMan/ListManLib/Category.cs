using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ListManLib
{
	public class Category : INotifyPropertyChanged
	{
		private string _categoryName;
		private ObservableCollection<TaskModel> _taskList;

		public string CategoryName
		{
			get { return _categoryName; }
			set
			{
				_categoryName = value;
				OnPropertyChanged("CategoryName");
			}
		}

		public ObservableCollection<TaskModel> TaskList
		{
			get { return _taskList; }
			set
			{
				_taskList = value;
				OnPropertyChanged("TaskList");
			}
		}
		public Category() { }
		public Category(string name)
		{
			_categoryName = name;
			_taskList = new ObservableCollection<TaskModel>();
		}

		public void AddTask(string name, DateTime date)
		{
			_taskList.Add(new TaskModel(name, date));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
