using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ListManLib
{
	public class TaskModel : INotifyPropertyChanged
	{
		private string _name;
		private DateTime _date;
		private bool _isCompleted;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged("TaskName");
			}
		}
		public DateTime Date
		{
			get { return _date; }
			set 
			{
				_date = value;
				OnPropertyChanged("Date");
			}
		}
		public bool IsCompleted
		{
			get { return _isCompleted; }
			set
			{
				_isCompleted = value;
				OnPropertyChanged("IsCompleted");
			}
		}

		public TaskModel() { }
		public TaskModel(string name, DateTime date, bool isCompleted = false)
		{
			_name = name;
			_date = date;
			_isCompleted = isCompleted;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
