using TMPro;
using UnityEngine;

namespace TestAssignment
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsText;


        public void UpdateCoinsText(int coinsValue)
        {
            _coinsText.text = coinsValue.ToString();
        }
    }
}
