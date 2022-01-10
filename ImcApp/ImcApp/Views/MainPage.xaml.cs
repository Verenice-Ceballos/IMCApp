using ImcApp.Models;
using System;
using Xamarin.Forms;
using ImcApp.ViewModels;

namespace ImcApp.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }
    }
}
