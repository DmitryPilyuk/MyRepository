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
	public class CategoryListVM : INotifyPropertyChanged
	{
		private ObservableCollection<CategoryVM> _categoryList;
		private CategoryVM _selectedCategory;

		public ObservableCollection<CategoryVM> CategoryList
		{
			get { return _categoryList; }
			set
			{
				_categoryList = value;
				OnPropertyChanged("CategoryList");
			}
		}
		public CategoryVM SelectedCategory
		{
			get { return _selectedCategory; }
			set
			{
				if (_selectedCategory != value)
				{
					CategoryVM tmp = value;
					_selectedCategory = null;
					OnPropertyChanged("SelectedCategory");
					Navigation.PushAsync(new CategoryPage(tmp));
				}
			}
		}

		public ICommand CreateCategoryCommand { private set; get; }
		public ICommand DeleteCategoryCommand { private set; get; }
		public ICommand ConfirmCategoryCommand { private set; get; }
		public ICommand BackCommand { private set; get; }
		public ICommand EditCategoryCommand { private set; get; }
		public ICommand NewListCommand { private set; get; }
		public ICommand SaveCommand { private set; get; }
		public INavigation Navigation { get; set; }

		public CategoryListVM()
		{
			_categoryList = new ObservableCollection<CategoryVM>();
			CreateCategoryCommand = new Command(CreateCategory);
			DeleteCategoryCommand = new Command(DeleteCategory);
			ConfirmCategoryCommand = new Command(ConfirmCategory);
			EditCategoryCommand = new Command(EditCategory);
			NewListCommand = new Command(NewList);
			SaveCommand = new Command(Save);
			BackCommand = new Command(Back);
		}

		private void CreateCategory()
		{
			Navigation.PushAsync(new EditCategoryPage(new CategoryVM() { CategoryList = this}));
		}
		private void Back()
		{
			Navigation.PopAsync();
		}
		private void ConfirmCategory(object obj)
		{
			CategoryVM category = obj as CategoryVM;
			if (category.CategoryName == null || category.CategoryName.Trim() == String.Empty)
			{
				Application.Current.MainPage.DisplayAlert("Ошибка", "Название не может быть пустым", "OK");
			}
			else
			{
				if (category != null && !_categoryList.Contains(category))
				{
					_categoryList.Add(category);
				}
				Back();
			}
		}
		private void EditCategory(object obj)
		{
			CategoryVM category = obj as CategoryVM;
			if (category != null)
			{
				Navigation.PushAsync(new EditCategoryPage(category));
			}
		}
		private void DeleteCategory(object obj)
		{
			CategoryVM category = obj as CategoryVM;
			if (category != null)
			{
				_categoryList.Remove(category);
			}
		}
		private void NewList()
		{
			CategoryList = new ObservableCollection<CategoryVM>();
		}
		private void Save()
		{
			SaverAndLoader saver = new SaverAndLoader();
			saver.Save(CategoryList);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
