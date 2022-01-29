using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment
{
    public class PlateController : MonoBehaviour
    {
        [SerializeField] GameObject[] _burgerIngredientImages;

        private List<IngredientType> _burgerIngredients;


        /// <summary>
        /// Returns true if ingredient was successfully placed
        /// </summary>
        public bool PlaceIngredient(IngredientType ingredientType)
        {
            var isValid = ValidateHasRequiredPreviousIngredients(ingredientType);
            if (isValid)
            {
                _burgerIngredients.Add(ingredientType);
                _burgerIngredientImages[(int)ingredientType].SetActive(true);
            }

            return isValid;
        }

        public void ServerBurger()
        {
            // Server burger to customer

            ResetPlate();
        }

        private void Start()
        {
            _burgerIngredients = new List<IngredientType>();
        }

        private void ResetPlate()
        {
            foreach (var burgerIngredientImage in _burgerIngredientImages)
            {
                burgerIngredientImage.SetActive(false);
            }

            _burgerIngredients.Clear();
        }

        private bool ValidateHasRequiredPreviousIngredients(IngredientType ingredientType)
        {
            var hasBunAndBurger = _burgerIngredients.Contains(IngredientType.Bun) && _burgerIngredients.Contains(IngredientType.Burger);

            switch (ingredientType)
            {
                case IngredientType.Bun:
                    return !_burgerIngredients.Contains(ingredientType);
                case IngredientType.Burger:
                    return !_burgerIngredients.Contains(ingredientType) && _burgerIngredients.Contains(IngredientType.Bun);
                case IngredientType.Tomato:
                    return !_burgerIngredients.Contains(ingredientType) && hasBunAndBurger;
                case IngredientType.Salad:
                    return !_burgerIngredients.Contains(ingredientType) && hasBunAndBurger && !_burgerIngredients.Contains(IngredientType.Tomato);
                default:
                    return false;
            }
        }

    }
}
