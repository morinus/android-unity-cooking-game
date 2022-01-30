using UnityEngine;

namespace TestAssignment
{
    public class GameController : MonoBehaviour
    {
        [Header("Controllers")]
        [SerializeField] private JuiceMakerController _juiceMakerController;
        [SerializeField] private OvenController _ovenController;
        [SerializeField] private CustomerSpawnController _customerSpawnController;

        [Header("Views")]
        [SerializeField] private CoinsView _coinsView;
        [SerializeField] private GameTimeView _gameTimeView;

        [Header("Level Data")]
        [SerializeField] private LevelScriptable _levelData;

        private int _currentScore = 0;
        private float _timeElapsed = 0f;
        private bool _isRunning = false;

        public static GameController Singleton
        {
            get { return _gameController; }
        }

        private static GameController _gameController;

        public void IncreasePlayerScore()
        {
            _currentScore += _levelData.EarningPerFinishedOrder;
            _coinsView.UpdateCoinsText(_currentScore);
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _currentScore = 0;
            _timeElapsed = 0f;
            _gameController = this;
            _isRunning = true;

            _juiceMakerController.Init(_levelData.TimeToFillJuiceGlass);
            _ovenController.Init(_levelData.CookingTime, _levelData.BurnoutTime);
            _customerSpawnController.Init(_levelData.TimeBetweenCustomerSpawns);
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            _timeElapsed += Time.deltaTime;

            _gameTimeView.UpdateTimeText(_levelData.TimeDuration - (int)_timeElapsed);

            if (_timeElapsed >= _levelData.TimeDuration)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            Time.timeScale = 0f;
            _isRunning = false;

            Debug.Log("Game Over! Time is up!");
        }
    }
}
