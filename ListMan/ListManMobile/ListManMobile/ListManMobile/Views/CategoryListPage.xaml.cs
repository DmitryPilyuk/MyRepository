using ListManMobile.Models;
using ListManMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListManMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryListPage : ContentPage
	{
		public CategoryListPage()
		{
			InitializeComponent();
			SaverAndLoader loader = new SaverAndLoader();
			CategoryListVM categoryList = loader.Load();
			categoryList.Navigation = this.Navigation;
			BindingContext = categoryList;
		}
	}
}