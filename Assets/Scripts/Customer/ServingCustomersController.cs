using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestAssignment
{
    public class ServingCustomersController : MonoBehaviour
    {
        [SerializeField] private CustomerOrderController[] _customerOrderControllers;


        /// <summary>
        /// Returns true if the customer has been successfully served
        /// </summary>
        public bool ServeCustomer(List<IngredientType> ingredients)
        {
            var orderType = GetOrderTypeBasedOnIngredients(ingredients);

            foreach (var customerOrderController in _customerOrderControllers)
            {
                if (customerOrderController.gameObject.activeSelf)
                {
                    var hasCompletedOrder = customerOrderController.TryToCompleteOrder(orderType);

                    if (hasCompletedOrder)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public OrderType GetOrderTypeBasedOnIngredients(List<IngredientType> ingredients)
        {
            var recipes = GameController.Singleton.LevelData.Recipes;

            foreach (var recipe in recipes)
            {
                ingredients.Sort();
                recipe.Ingredients.Sort();

                if (Enumerable.SequenceEqual(recipe.Ingredients, ingredients))
                {
                    return recipe.OrderType;
                }
            }

            return OrderType.Invalid;
        }
    }
}
