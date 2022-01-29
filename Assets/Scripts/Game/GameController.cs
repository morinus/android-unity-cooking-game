using UnityEngine;

namespace TestAssignment
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private JuiceMakerController _juiceMakerController;
        [SerializeField] private OvenController _ovenController;
        [SerializeField] private CustomerSpawnController _customerSpawnController;

        [SerializeField] private CoinsView _coinsView;
        [SerializeField] private GameTimeView _gameTimeView;

        [SerializeField] private float _timetoFillJuiceGlass = 3f;
        [SerializeField] private float _cookingTime = 3f;
        [SerializeField] private float _burnoutTime = 10f;
        [SerializeField] private float _timeBetweenCustomerSpawns = 3f;
        [SerializeField] private int _timeToCompleteLevel = 60;

        public int MaxNumberOfOrders = 2;
        public GameObject[] OrderPrefabs;

        private int _currentScore = 0;
        private float _timeElapsed = 0f;
        private bool _isRunning = false;

        public static GameController Singleton
        {
            get { return _gameController; }
        }

        private static GameController _gameController;

        public void IncreasePlayerScore(int value)
        {
            _currentScore += value;
            _coinsView.UpdateCoinsText(_currentScore);
        }

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            _timeElapsed += Time.deltaTime;

            _gameTimeView.UpdateTimeText(_timeToCompleteLevel - (int)_timeElapsed);

            if (_timeElapsed >= _timeToCompleteLevel)
            {
                GameOver();
            }
        }

        private void Init()
        {
            _currentScore = 0;
            _timeElapsed = 0f;
            _gameController = this;
            _isRunning = true;

            _juiceMakerController.Init(_timetoFillJuiceGlass);
            _ovenController.Init(_cookingTime, _burnoutTime);
            _customerSpawnController.Init(_timeBetweenCustomerSpawns);
        }

        private void GameOver()
        {
            Time.timeScale = 0f;
            _isRunning = false;

            Debug.Log("Game Over! Time is up!");
        }
    }
}
