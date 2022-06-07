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
	public partial class TaskPage : ContentPage
	{
		public TaskVM Task { get; private set; }
		public TaskPage(TaskVM task)
		{
			InitializeComponent();
			Task = task;
			this.BindingContext = Task;
		}
	}
}