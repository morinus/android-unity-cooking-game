using UnityEngine;

namespace TestAssignment
{
    public class BurgerBuildingController : MonoBehaviour
    {
        [SerializeField] private PlateController[] _plateControllers;

        public void PlaceIngredient(int ingredientType)
        {
            foreach (var plateController in _plateControllers)
            {
                var hasPutIngredientToPlate = plateController.PlaceIngredient((IngredientType)ingredientType);
                if (hasPutIngredientToPlate)
                {
                    return;
                }
            }
        }
    }
}
