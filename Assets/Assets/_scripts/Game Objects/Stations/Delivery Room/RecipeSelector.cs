using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Space.Objects
{
    public class RecipeSelector : MonoBehaviour
    {
        public event Action<List<GameObject>> OnRecipeSelected; 

        [SerializeField] private List<Recipe> recipes; 
        [SerializeField] private Button recipeButtonPrefab;
        [SerializeField] private Transform recipeListContainer;
        [SerializeField] private GameObject recipePanel;

        private void Start()
        {
            PopulateRecipeMenu();
        }

        private void PopulateRecipeMenu()
        {
            foreach (Recipe recipe in recipes)
            {
                Button newButton = Instantiate(recipeButtonPrefab, recipeListContainer);
                newButton.GetComponentInChildren<Text>().text = recipe.recipeName;
                newButton.onClick.AddListener(() => SelectRecipe(recipe));
            }
        }

        private void SelectRecipe(Recipe recipe)
        {
            OnRecipeSelected?.Invoke(recipe.ingredients);
            recipePanel.SetActive(false); // Fecha o menu após escolher
        }

        public void OpenRecipePanel()
        {
            recipePanel.SetActive(true);
        }
    }

    [Serializable]
    public class Recipe
    {
        public string recipeName;
        public List<GameObject> ingredients;
    }
}

