using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokemonApp.ViewModels;

namespace PokemonApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void EvolveButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is EvolutionItem evolutionItem)
            {
                (BindingContext as MainPageViewModel)?.EvolveCommand.Execute(evolutionItem);
            }
        }
    }
}
