using ListManMobile.Models;
using ListManMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListManMobile.ViewModels
{
	public class CategoryVM : INotifyPropertyChanged
	{
		private string _categoryName;
		private ObservableCollection<TaskVM> _taskList;
		private TaskVM _selectedTask;
		private CategoryListVM _categoryList;

		public CategoryListVM CategoryList
		{
			get { return _categoryList; }
			set
			{
				_categoryList = value;
				OnPropertyChanged("ListViewModel");
			}
		}
		public string CategoryName
		{
			get { return _categoryName; }
			set
			{
				_categoryName = value;
				OnPropertyChanged("CategoryName");
			}
		}
		public ObservableCollection<TaskVM> TaskList
		{
			get { return _taskList; }
			set
			{
				_taskList = value;
				OnPropertyChanged("TaskList");
			}
		}
		public TaskVM SelectedTask
		{
			get { return _selectedTask; }
			set
			{
				if (_selectedTask != value)
				{
					TaskVM tmp= value;
					_selectedTask = null;
					OnPropertyChanged("SelectedTask");
					Navigation.PushAsync(new TaskPage(tmp));
				}
			}
		}

		public ICommand CreateTaskCommand { protected set; get; }
		public ICommand DeleteTaskCommand { protected set; get; }
		public ICommand ConfirmTaskCommand { protected set; get; }
		public ICommand BackCommand { protected set; get; }
		
		public INavigation Navigation 
		{
			get { return _categoryList.Navigation; }
		}

		public CategoryVM(Category category, CategoryListVM categoryList)
		{
			_categoryName = category.CategoryName;
			_categoryList = categoryList;
			_taskList = new ObservableCollection<TaskVM>();
			foreach(var task in category.Tasks)
			{
				_taskList.Add(new TaskVM(task, this));
			}
			CreateTaskCommand = new Command(CreateTask);
			DeleteTaskCommand = new Command(DeleteTask);
			ConfirmTaskCommand = new Command(ConfirmTask);
			BackCommand = new Command(Back);
		}
		public CategoryVM()
		{
			_taskList = new ObservableCollection<TaskVM>();
			CreateTaskCommand = new Command(CreateTask);
			DeleteTaskCommand = new Command(DeleteTask);
			ConfirmTaskCommand = new Command(ConfirmTask);
			BackCommand = new Command(Back);
		}

		private void CreateTask()
		{
			Navigation.PushAsync(new TaskPage(new TaskVM() { TaskList = this }));
		}
		private void Back()
		{
			Navigation.PopAsync();
		}
		private void ConfirmTask(object obj)
		{
			TaskVM task = obj as TaskVM;
			
			if (task.Name == null || task.Name.Trim() == String.Empty)
			{
				Application.Current.MainPage.DisplayAlert("Ошибка", "Название не может быть пустым", "OK");
			}
			else
			{
				if (task != null && !_taskList.Contains(task))
				{
					_taskList.Add(task);
				}
				Back();
			}
		}
		private void DeleteTask(object obj)
		{
			TaskVM task = obj as TaskVM;
			if (task != null)
			{
					_taskList.Remove(task);
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
