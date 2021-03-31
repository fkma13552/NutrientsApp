using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using NutrientsApp.Data.Repositories;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services;
using NutrientsApp.Services.Abstract;
using NutrientsApp.WPF.UI.Commands;

namespace NutrientsApp.WPF.UI.ViewModels
{
    public class ApplicationViewModel: INotifyPropertyChanged
    {
        private IRecipesService recipesService;

        private Recipe selectedFromAllRecipe;
        private Recipe selectedFromChosenRecipe;
        
        public Recipe SelectedFromAllRecipe
        {
            get { return selectedFromAllRecipe; }
            set { selectedFromAllRecipe = value; OnPropertyChanged("SelectedFromAllRecipe"); }
        }
        public Recipe SelectedFromChosenRecipe
        {
            get { return selectedFromChosenRecipe; }
            set { selectedFromChosenRecipe = value; OnPropertyChanged("SelectedFromChosenRecipe"); }
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
                    ChosenRecipes.Add(SelectedFromAllRecipe), obj => selectedFromAllRecipe != null);
            }
        }
        public RelayCommand UnchooseRecipe
        {
            get
            {
                return unchooseRecipe ?? new RelayCommand(obj =>
                    ChosenRecipes.Remove(SelectedFromChosenRecipe), obj => selectedFromChosenRecipe != null);
            }
        }
        public RelayCommand CountNutrientsFromRecipes
        {
            get
            {
                return countNutrientsFromRecipes ?? new RelayCommand(obj =>
                {
                    int p = 0;
                    int c = 0;
                    int f = 0;
                    foreach (var recipe in ChosenRecipes)
                    {
                        p += recipesService.GetRecipeProteins(recipe);
                        c += recipesService.GetRecipeCarbohydrates(recipe);
                        f += recipesService.GetRecipeFats(recipe);
                    }
                    MessageBox.Show(
                        $"Your day will contain {p} proteins, {c} carbohydrates and {f} fats. Have a nice day!");
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationViewModel()
        {
            recipesService = new RecipesService(new RecipesRepository<IngredientEntity>(
                new IngredientsRepository(), new ProductsRepository()), new ProductsService(new ProductsRepository()));
            AllRecipes = new ObservableCollection<Recipe>(recipesService.GetAll());
            ChosenRecipes = new ObservableCollection<Recipe>();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}