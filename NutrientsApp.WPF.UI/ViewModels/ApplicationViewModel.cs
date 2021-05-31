using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services;
using NutrientsApp.Services.Abstract;
using NutrientsApp.WPF.UI.Commands;

namespace NutrientsApp.WPF.UI.ViewModels
{
    public class ApplicationViewModel: INotifyPropertyChanged
    {
        private readonly IRecipesService _recipesService;
        private readonly IProductNutrientsService _productNutrientsService;
        private readonly INutrientComponentsService _nutrientComponentsService;

        private Recipe _selectedFromAllRecipe;
        private Recipe _selectedFromChosenRecipe;
        
        public Recipe SelectedFromAllRecipe
        {
            get { return _selectedFromAllRecipe; }
            set { _selectedFromAllRecipe = value; OnPropertyChanged("SelectedFromAllRecipe"); }
        }
        public Recipe SelectedFromChosenRecipe
        {
            get { return _selectedFromChosenRecipe; }
            set { _selectedFromChosenRecipe = value; OnPropertyChanged("SelectedFromChosenRecipe"); }
        }
        
        public ObservableCollection<Recipe> AllRecipes { get; set; }
        public ObservableCollection<Recipe> ChosenRecipes { get; set; }
        
        private RelayCommand unchooseRecipe;
        private RelayCommand chooseRecipe;
        private RelayCommand countNutrientsFromRecipes;
        
        public RelayCommand ChooseRecipe
        {
            get
            {
                return chooseRecipe ?? new RelayCommand(obj =>
                    ChosenRecipes.Add(SelectedFromAllRecipe), obj => _selectedFromAllRecipe != null);
            }
        }
        public RelayCommand UnchooseRecipe
        {
            get
            {
                return unchooseRecipe ?? new RelayCommand(obj =>
                    ChosenRecipes.Remove(SelectedFromChosenRecipe), obj => _selectedFromChosenRecipe != null);
            }
        }
        public RelayCommand CountNutrientsFromRecipes
        {
            get
            {
                return countNutrientsFromRecipes ?? new RelayCommand(obj =>
                {

                    IDictionary<string, int> allNutrients = new Dictionary<string, int>();
                    foreach (var recipe in ChosenRecipes)
                    {
                        IDictionary<string, int> nutrients = _recipesService.GetRecipeNutrients(recipe);
                        foreach (KeyValuePair<string, int> kv in nutrients)
                        {
                            if (allNutrients.ContainsKey(kv.Key))
                            {
                                allNutrients[kv.Key] += kv.Value;
                            }
                            else
                            {
                                allNutrients[kv.Key] = kv.Value;
                            }
                        }
                    }

                    int p = allNutrients["Proteins"];
                    int c = allNutrients["Carbohydrates"];
                    int f = allNutrients["Fats"];
                    MessageBox.Show(
                        $"Your day will contain {p} proteins, {c} carbohydrates and {f} fats. Have a nice day!");
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationViewModel(IRecipesService recipesService, IProductNutrientsService productNutrientsService, 
            INutrientComponentsService nutrientComponentsService)
        {
            _recipesService = recipesService;
            _productNutrientsService = productNutrientsService;
            _nutrientComponentsService = nutrientComponentsService;
            AllRecipes = new ObservableCollection<Recipe>(_recipesService.GetAll());
            ChosenRecipes = new ObservableCollection<Recipe>();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}