using UnityEngine;

namespace TestAssignment.PLL
{
    public class OvenController : MonoBehaviour
    {
        [SerializeField] private PanView[] _paneViews;


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

        private void Start()
        {
            foreach (var panView in _paneViews)
            {
                panView.Init(3f, 10f);
            }
        }
    }
}
