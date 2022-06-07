using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ListManLib;

namespace ListMan
{
	internal class MainVM : INotifyPropertyChanged
	{
		private string _newTaskName;
		public string NewTaskName
		{
			get { return _newTaskName; }
			set
			{
				_newTaskName = value;
				OnPropertyChanged("NewTaskName");
			}
		}

		private DateTime _newTaskDate;
		public DateTime NewTaskDate
		{
			get { return _newTaskDate; }
			set
			{
				_newTaskDate = value;
				OnPropertyChanged("NewTaskDate");
			}
		}

		private string _newCategoryName;
		public string NewCategoryName
		{
			get { return _newCategoryName; }
			set
			{
				_newCategoryName = value;
				OnPropertyChanged("NewCategoryName");
			}
		}

		private CategoryList _categories;
		public ObservableCollection<Category> Categories 
		{
			get { return _categories.Categories; }
		}

		private RelayCommand _addTask;
		public RelayCommand AddTask
		{
			get
			{
				return _addTask ??= new RelayCommand(obj =>
				{
					if (_selectedCategory != null)
					{
						_selectedCategory.AddTask(NewTaskName, NewTaskDate);
						OnPropertyChanged("TaskList");
						NewTaskName = "";
						NewTaskDate = DateTime.Now;
					}
					else
					{
						MessageBox.Show("Выберите категорию");
					}
				});
			}
		}

		private RelayCommand _addCategory;
		public RelayCommand AddCategory
		{
			get
			{
				return _addCategory ??= new RelayCommand(obj =>
				{
					if (NewCategoryName != String.Empty)
					{
						_categories.AddCategory(NewCategoryName);
						NewCategoryName = "";
					}
					else
					{
						MessageBox.Show("Имя категории пустое");
					}
				});
			}
		}

		private RelayCommand _delCategory;
		public RelayCommand DelCategory
		{
			get
			{
				return _delCategory ??= new RelayCommand(obj =>
				{
					if (_selectedCategory != null)
					{
						_categories.DelCategory(SelectedCategory);
					}
					else
					{
						MessageBox.Show("Категория не выбрана.");
					}
				});
			}
		}

		private RelayCommand _saveList;
		public RelayCommand SaveList
		{
			get
			{
				return _saveList ??= new RelayCommand(obj =>
				{
					SaverAndLoader saver = new SaverAndLoader();
					saver.Save(_categories);
				});
			}
		}

		private RelayCommand _createNewList;
		public RelayCommand CreateNewList
		{
			get
			{
				return _createNewList ??= new RelayCommand(obj =>
				{
					_categories = new CategoryList();
					OnPropertyChanged("Categories");
				});
			}
		}

		private Category _selectedCategory;
		public Category SelectedCategory
		{
			get { return _selectedCategory; }
			set
			{
				_selectedCategory = value;
				OnPropertyChanged("SelectedCategory");
				OnPropertyChanged("TaskList");
			}
		}

		public ObservableCollection<TaskModel> TaskList
		{
			get 
			{
				if(_selectedCategory!=null) return _selectedCategory.TaskList; 
				else return null;
			}
		}

		private TaskModel _currentTask;
		public TaskModel CurrentTask
		{
			get { return _currentTask; }
			set
			{
				_currentTask = value;
				OnPropertyChanged("CurrentTask");
			}
		}

		public MainVM()
		{
			SaverAndLoader loader = new SaverAndLoader();
			_categories = loader.Load();
			_newTaskDate = DateTime.Now;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
