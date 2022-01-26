using TestAssignment.Model;
using UnityEngine;

namespace TestAssignment.PLL
{
    public class PlateView : MonoBehaviour
    {
        [SerializeField] GameObject[] _burgerIngredients;


        /// <summary>
        /// Returns true if ingredient was successfully placed
        /// </summary>
        public bool PlaceIngredient(IngredientType ingredientType)
        {
            var isValid = ValidateHasRequiredPreviousIngredients(ingredientType);

            if (isValid)
            {
                _burgerIngredients[(int)ingredientType].SetActive(true);
            }

            return isValid;
        }

        private bool ValidateHasRequiredPreviousIngredients(IngredientType ingredientType)
        {
            switch (ingredientType)
            {
                case IngredientType.Bun:
                    return !_burgerIngredients[0].activeSelf;
                case IngredientType.Burger:
                    return _burgerIngredients[0].activeSelf && !_burgerIngredients[1].activeSelf;
                case IngredientType.Salad:
                    return _burgerIngredients[0].activeSelf && _burgerIngredients[1].activeSelf && !_burgerIngredients[2].activeSelf;
                case IngredientType.Tomato:
                    return _burgerIngredients[0].activeSelf && _burgerIngredients[1].activeSelf && !_burgerIngredients[3].activeSelf;
                default:
                    return false;
            }
        }

    }
}
