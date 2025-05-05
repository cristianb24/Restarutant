using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Text.Json;
using suckMyBawls.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace suckMyBawls.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<Recipe> Recipes { get; set; } = new();
        public ObservableCollection<Recipe> CurrentOrders { get; set; } = new();
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new();

        [ObservableProperty]
        private bool pizzaIsOpen = false;

        private Dictionary<string, Recipe> recipeLookup = new();

        public MainWindowViewModel()
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var json = File.ReadAllText("data.json");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var data = JsonSerializer.Deserialize<Root>(json, options);
                if (data != null)
                {
                    if (data.Recipes != null)
                        Recipes = new ObservableCollection<Recipe>(data.Recipes);
                    if (data.Ingredients != null)
                        Ingredients = new ObservableCollection<Ingredient>(data.Ingredients);

                    recipeLookup = data.Recipes?
                        .ToDictionary(r => r.Name, r => r) ?? new Dictionary<string, Recipe>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task StartRecipeProgressAsync(Recipe recipe)
        {
            CurrentOrders.Add(recipe);
            int totalDuration = 0;
            foreach (var step in recipe.Steps)
            {
                totalDuration += step.Duration;
            }

            ProgressValue = 0;
            int elapsed = 0;
            while (elapsed < totalDuration)
            {
                await Task.Delay(1000);
                elapsed++;
                ProgressValue = (elapsed / (double)totalDuration) * 100;
            }

            ProgressValue = 100;
        }

        [RelayCommand]
        private async Task AddRecipeByNameAsync(string recipeName)
        {
            if (recipeLookup.TryGetValue(recipeName, out var recipe))
            {
                await StartRecipeProgressAsync(recipe);
            }
        }
        [RelayCommand]
        private void PizzaPressed() => PizzaIsOpen ^= true;

        [ObservableProperty]
        private double progressValue;
    }
}