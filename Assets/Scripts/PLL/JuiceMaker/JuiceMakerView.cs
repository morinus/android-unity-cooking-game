using UnityEngine;
using UnityEngine.UI;

namespace TestAssignment.PLL
{
    public class JuiceMakerView : MonoBehaviour
    {
        [SerializeField] private GameObject _juiceGlass;
        [SerializeField] private Image _timerImage;


        private void Start()
        {
            InitializeGlass();
        }

        private void InitializeGlass()
        {
            SetGlassVisible(false);
        }


        public void SetGlassVisible(bool isVisible)
        {
            _juiceGlass.SetActive(isVisible);
        }

        public void SetTimerFill(float fillAmount)
        {
            _timerImage.fillAmount = fillAmount;
        }
    }
}
