using TMPro;
using UnityEngine;

namespace TestAssignment.PLL
{
    public class GameTimeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameTimeText;


        public void UpdateTimeText(int timeLeft)
        {
            _gameTimeText.text = timeLeft.ToString();
        }
    }
}
