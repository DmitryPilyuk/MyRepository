using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ListManMobile.Models
{
	public class TaskModel
	{
		private string _name;
		private DateTime _date;
		private bool _isCompleted;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}
		public bool IsCompleted
		{
			get { return _isCompleted; }
			set { _isCompleted = value; }
		}

		public TaskModel()
		{
			_date = DateTime.Now;
		}
	}
}
