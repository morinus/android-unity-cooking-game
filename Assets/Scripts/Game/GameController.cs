using UnityEngine;
using UnityEngine.SceneManagement;

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

        [Header("Canvases")]
        [SerializeField] private GameObject _endGameWindow;
        [SerializeField] private GameObject _goalAchieved;
        [SerializeField] private GameObject _goalFailed;


        private int _currentScore = 0;
        private float _timeElapsed = 0f;
        private bool _isRunning = false;

        public static GameController Singleton
        {
            get { return _gameController; }
        }

        public LevelScriptable LevelData
        {
            get { return _levelData; }
        }

        private static GameController _gameController;

        public void IncreasePlayerScore()
        {
            _currentScore += _levelData.EarningPerFinishedOrder;
            _coinsView.UpdateCoinsText(_currentScore);

            CheckForLevelCompleted();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);

            Init();
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            Time.timeScale = 1f;

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
            StopGame();
            ShowGameOverWindow();
        }

        private void CheckForLevelCompleted()
        {
            if (_currentScore >= LevelData.ScoreRequiredToFinishLevel)
            {
                StopGame();
                ShowLevelCompletedWindow();
            }
        }

        private void StopGame()
        {
            Time.timeScale = 0f;
            _isRunning = false;
        }

        private void ShowGameOverWindow()
        {
            _endGameWindow.SetActive(true);
            _goalFailed.SetActive(true);

            Debug.Log("Game Over! Time is up!");
        }

        private void ShowLevelCompletedWindow()
        {
            _endGameWindow.SetActive(true);
            _goalAchieved.SetActive(true);

            Debug.Log("Level Compeleted!");
        }
    }
}
