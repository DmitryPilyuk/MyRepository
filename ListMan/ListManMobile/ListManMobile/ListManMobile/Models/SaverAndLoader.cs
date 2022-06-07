using ListManMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ListManMobile.Models
{
	public class SaverAndLoader
	{
		private readonly string _path;
		private XmlSerializer _xmlSerializer;
		public SaverAndLoader()
		{
			_path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\savedData.xml";
			_xmlSerializer = new XmlSerializer(typeof(List<Category>));
		}

		public void Save(ObservableCollection<CategoryVM> categoryList)
		{
			List<Category> categories = new List<Category>();
			for (int i = 0; i < categoryList.Count; i++)
			{
				categories.Add(new Category(categoryList[i]));
			}
			using (FileStream fs = new FileStream(_path, FileMode.Create))
			{
				_xmlSerializer.Serialize(fs, categories);
			}
		}

		public CategoryListVM Load()
		{
			if (!File.Exists(_path))
			{
				return new CategoryListVM();
			}
			using (FileStream fs = new FileStream(_path, FileMode.Open))
			{
				var categories = _xmlSerializer.Deserialize(fs) as List<Category>;
				CategoryListVM categoryList = new CategoryListVM();
				foreach (var category in categories)
				{
					categoryList.CategoryList.Add(new CategoryVM(category, categoryList));
				}
				return categoryList;
			}
		}
	}
}
