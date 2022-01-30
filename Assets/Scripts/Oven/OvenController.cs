using UnityEngine;

namespace TestAssignment
{
    public class OvenController : MonoBehaviour
    {
        [SerializeField] private BurgerBuildingController _burgerBuildingController;
        [SerializeField] private PanController[] _panControllers;


        public void Init(float cookingTime, float burnoutTime)
        {
            foreach (var panController in _panControllers)
            {
                panController.Init(cookingTime, burnoutTime);
            }
        }

        public void PlaceBurger()
        {
            foreach (var panController in _panControllers)
            {
                var hasPlacedBurger = panController.PlaceBurger();
                if (hasPlacedBurger)
                {
                    return;
                }
            }
        }
    }
}
