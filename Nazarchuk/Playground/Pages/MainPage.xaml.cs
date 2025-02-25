using Playground.Models;
using Playground.PageModels;
using System.Threading.Tasks;

namespace Playground.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }


}