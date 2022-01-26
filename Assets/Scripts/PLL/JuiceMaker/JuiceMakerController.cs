using UnityEngine;


namespace TestAssignment.PLL
{
    public class JuiceMakerController : MonoBehaviour
    {
        [SerializeField] private JuiceMakerView _juiceMakerView;
        [SerializeField] private float _timeToRefillJuiceGlass;

        private bool _isJuiceGlassAvailable = false;
        private bool _isFillingJuiceGlass = false;
        private float _timeElapsed = 0f;


        private void StartFillingJuiceGlass()
        {
            var canFillJuiceGlass = !_isJuiceGlassAvailable && !_isFillingJuiceGlass;
            if (canFillJuiceGlass)
            {
                _timeElapsed = 0f;
                _isFillingJuiceGlass = true;
            }
        }

        private void OnFinishedFillingJuiceGlass()
        {
            _isFillingJuiceGlass = false;
            _isJuiceGlassAvailable = true;

            _juiceMakerView.SetTimerFill(0f);
            _juiceMakerView.SetGlassVisible(true);
        }

        private void Update()
        {
            if (_isFillingJuiceGlass)
            {
                _timeElapsed += Time.deltaTime;
                _juiceMakerView.SetTimerFill(_timeElapsed / _timeToRefillJuiceGlass);

                if (_timeElapsed >= _timeToRefillJuiceGlass)
                {
                    OnFinishedFillingJuiceGlass();
                }
            }
        }


        public void FillJuiceGlass()
        {
            if (!_isJuiceGlassAvailable)
            {
                StartFillingJuiceGlass();
            }
        }

        public void ServeJuiceGlass()
        {
            if (_isJuiceGlassAvailable)
            {
                _isJuiceGlassAvailable = false;
                _juiceMakerView.SetGlassVisible(false);
            }

            // Serve Juice Glass
        }
    }
}
