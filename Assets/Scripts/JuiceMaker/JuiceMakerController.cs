using UnityEngine;

namespace TestAssignment
{
    public class JuiceMakerController : MonoBehaviour
    {
        [SerializeField] private JuiceMakerView _juiceMakerView;

        private bool _isJuiceGlassAvailable = false;
        private bool _isFillingJuiceGlass = false;
        private float _timeToFillJuiceGlass = 0f;
        private float _timeElapsed = 0f;


        public void Init(float timeToFillJuiceGlass)
        {
            _timeToFillJuiceGlass = timeToFillJuiceGlass;
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
                _juiceMakerView.SetTimerFill(_timeElapsed / _timeToFillJuiceGlass);

                if (_timeElapsed >= _timeToFillJuiceGlass)
                {
                    OnFinishedFillingJuiceGlass();
                }
            }
        }
    }
}
