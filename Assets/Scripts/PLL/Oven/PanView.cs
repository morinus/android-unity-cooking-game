using UnityEngine;
using UnityEngine.UI;

namespace TestAssignment.PLL
{
    public class PanView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _burgerStages;
        [SerializeField] private Image _greenTimerImage;
        [SerializeField] private Image _redTimerImage;

        private bool _hasBurger = false;
        private bool _burgerFinishedCooking = false;
        private bool _hasBurnout = false;
        private float _cookingTime = 0f;
        private float _burnoutTime = 0f;
        private float _timeElapsed = 0f;

        public void Init(float cookingTime, float burnoutTime)
        {
            _cookingTime = cookingTime;
            _burnoutTime = burnoutTime;
        }

        /// <summary>
        /// Returns true if burger has been successfully placed on the oven
        /// </summary>
        public bool PlaceBurger()
        {
            if (!_hasBurger)
            {
                _burgerStages[0].SetActive(true);
                _hasBurger = true;

                StartGreenTimer();

                return true;
            }

            return false;
        }

        public void RemoveBurger()
        {
            foreach (var burgerStage in _burgerStages)
            {
                burgerStage.SetActive(false);
            }

            _hasBurger = false;
            _hasBurnout = false;
            _burgerFinishedCooking = false;
            _timeElapsed = 0f;
            _redTimerImage.gameObject.SetActive(false);
        }

        private void StartGreenTimer()
        {
            _greenTimerImage.gameObject.SetActive(true);
            _greenTimerImage.fillAmount = 0f;
        }

        private void StartRedTimer()
        {
            _greenTimerImage.gameObject.SetActive(false);
            _redTimerImage.gameObject.SetActive(true);
            _redTimerImage.fillAmount = 0f;
        }

        private void Update()
        {
            if (_hasBurger && !_burgerFinishedCooking)
            {
                _timeElapsed += Time.deltaTime;

                _greenTimerImage.fillAmount = _timeElapsed / _cookingTime;

                var hasFinishedCooking = _timeElapsed >= _cookingTime;
                if (hasFinishedCooking)
                {
                    StartRedTimer();

                    _burgerFinishedCooking = true;
                    _timeElapsed = 0f;
                    _burgerStages[1].SetActive(true);
                }
            }

            if (_hasBurger && _burgerFinishedCooking && !_hasBurnout)
            {
                _timeElapsed += Time.deltaTime;
                _redTimerImage.fillAmount = _timeElapsed / _burnoutTime;

                var hasBurnedOut = _timeElapsed >= _burnoutTime;
                if (hasBurnedOut)
                {
                    _burgerStages[1].SetActive(false);
                    _burgerStages[2].SetActive(true);
                    _redTimerImage.gameObject.SetActive(false);
                    _hasBurnout = true;
                }
            }
        }
    }
}
