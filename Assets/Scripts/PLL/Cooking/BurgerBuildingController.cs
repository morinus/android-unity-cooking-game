using TestAssignment.Model;
using UnityEngine;

namespace TestAssignment.PLL
{
    public class BurgerBuildingController : MonoBehaviour
    {
        [SerializeField] private PlateView[] _plateViews;


        public void PlaceIngredient(int ingredientType)
        {
            foreach (var plateView in _plateViews)
            {
                var hasPutIngredientToPlate = plateView.PlaceIngredient((IngredientType)ingredientType);
                if (hasPutIngredientToPlate)
                {
                    return;
                }
            }
        }
    }
}
