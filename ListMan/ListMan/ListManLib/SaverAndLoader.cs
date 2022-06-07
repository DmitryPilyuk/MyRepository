using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ListManLib
{
	public class SaverAndLoader
	{
		private readonly string _path;
		private XmlSerializer _xmlSerializer; 
		public SaverAndLoader()
		{
			_path = "savedData.xml";
			_xmlSerializer = new XmlSerializer(typeof(CategoryList));
		}

		public void Save(CategoryList categoryList)
		{
			using(FileStream fs = new FileStream(_path, FileMode.Create))
			{
				_xmlSerializer.Serialize(fs, categoryList);
			}
		}

		public CategoryList Load()
		{
			if (!File.Exists(_path))
			{
				return new CategoryList();
			}
			using (FileStream fs = new FileStream(_path, FileMode.Open))
			{
				return _xmlSerializer.Deserialize(fs) as CategoryList;
			}
		}
	}
}
