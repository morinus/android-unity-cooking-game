using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment
{
    [CreateAssetMenu(fileName = "RecipeData", menuName = "Scriptables/RecipeData")]
    public class RecipeScriptable : ScriptableObject
    {
        [Header("Recipe Settings")]
        public OrderType OrderType;
        public GameObject RecipePrefab;
        public List<IngredientType> Ingredients;
    }
}
