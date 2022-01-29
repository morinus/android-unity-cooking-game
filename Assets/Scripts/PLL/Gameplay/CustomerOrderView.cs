using UnityEngine;
using UnityEngine.UI;

namespace TestAssignment.PLL
{
    public class CustomerOrderView : MonoBehaviour
    {
        [SerializeField] private Image _fillBarImage;
        [SerializeField] private float _timeToServeOrder = 30f;

        private float _timeElapsed = 0f;


        private void OnEnable()
        {
            _fillBarImage.fillAmount = 1f;
            _timeElapsed = 0f;
        }

        private void Update()
        {
            _timeElapsed += Time.deltaTime;

            _fillBarImage.fillAmount = 1f - (_timeElapsed / _timeToServeOrder);

            if (_timeElapsed >= _timeToServeOrder)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
