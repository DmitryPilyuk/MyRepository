using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListManLib
{
	public class CategoryList : INotifyPropertyChanged
	{
		private ObservableCollection<Category> _categories;

		public ObservableCollection<Category> Categories
		{
			get { return _categories; }
			set
			{
				_categories = value;
				OnPropertyChanged("Categories");
			}
		}

		public CategoryList()
		{
			_categories = new ObservableCollection<Category>();
		}

		public void AddCategory(string name)
		{
			_categories.Add(new Category(name));
		}
		
		public void DelCategory(Category category)
		{
			if (category != null)
			{
				_categories.Remove(category);
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