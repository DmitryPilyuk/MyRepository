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
	public partial class CategoryPage : ContentPage
	{
		public CategoryVM Category { get; private set; }
		public CategoryPage(CategoryVM category)
		{
			InitializeComponent();
			Category = category;
			this.BindingContext = Category;
		}
	}
}