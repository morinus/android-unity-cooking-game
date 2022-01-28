using UnityEngine;

namespace TestAssignment.PLL
{
    public class OvenController : MonoBehaviour
    {
        [SerializeField] private PanView[] _paneViews;


        public void Init(float cookingTime, float burnoutTime)
        {
            foreach (var panView in _paneViews)
            {
                panView.Init(cookingTime, burnoutTime);
            }
        }

        public void PlaceBurger()
        {
            foreach (var panView in _paneViews)
            {
                var hasPlacedBurger = panView.PlaceBurger();
                if (hasPlacedBurger)
                {
                    return;
                }
            }
        }
    }
}
