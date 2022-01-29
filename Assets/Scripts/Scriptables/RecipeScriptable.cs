using UnityEngine;

namespace TestAssignment
{
    [CreateAssetMenu(fileName = "RecipeData", menuName = "Scriptables/RecipeData")]
    public class RecipeScriptable : ScriptableObject
    {
        [Header("RecipePrefab")]
        public GameObject RecipePrefab;

        [Header("Ingredients")]
        public IngredientType[] Ingredients;
    }
}
