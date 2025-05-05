using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Text.Json;
using suckMyBawls.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace suckMyBawls.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool pizzaIsOpen = false;

        [RelayCommand]
        private void PizzaPressed() => PizzaIsOpen ^= true;

        [ObservableProperty]
        private double progressValue;

        public List<Ingredient> Ingredients { get; set; }

        [ObservableProperty]
        private ObservableCollection<Recipe> recipes = new();

        [RelayCommand]
        private async Task StartProgressAsync()
        {
            ProgressValue = 0;
            while (ProgressValue < 100)
            {
                await Task.Delay(50); // Velocidad de animación
                ProgressValue += 2;
            }
        }
    }
}