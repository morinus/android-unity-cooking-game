using UnityEngine;

namespace TestAssignment.PLL
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private OvenController _ovenController;
        [SerializeField] private CustomerSpawnController _customerSpawnController;
        [SerializeField] private CoinsView _coinsView;
        [SerializeField] private GameTimeView _gameTimeView;

        [SerializeField] private float _cookingTime = 3f;
        [SerializeField] private float _burnoutTime = 10f;
        [SerializeField] private float _timeBetweenCustomerSpawns = 3f;
        [SerializeField] private int _timeToCompleteLevel = 60;

        private int _currentScore = 0;
        private float _timeElapsed = 0f;


        private void Start()
        {
            Init();
        }

        private void Update()
        {
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

            _ovenController.Init(_cookingTime, _burnoutTime);
            _customerSpawnController.Init(_timeBetweenCustomerSpawns);
        }

        private void IncreasePlayerScore(int value)
        {
            _currentScore += value;
            _coinsView.UpdateCoinsText(_currentScore);
        }

        private void GameOver()
        {
            Debug.Log("Game Over! Time is up!");
        }
    }
}
