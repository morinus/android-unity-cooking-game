using UnityEngine;

namespace TestAssignment
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Scriptables/LevelData")]
    public class LevelScriptable : ScriptableObject
    {
        [Header("Juicemarker Settings")]
        public float TimeToFillJuiceGlass;

        [Header("Oven Settings")]
        public float CookingTime;
        public float BurnoutTime;

        [Header("Customer Settings")]
        public float TimeBetweenCustomerSpawns;
        public float TimeToServeCustomer;

        [Header("Level Settings")]
        public int TimeDuration;

        [Header("Available Recipes")]
        public RecipeScriptable[] Recipes;
    }
}
