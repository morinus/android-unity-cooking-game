using UnityEngine;

namespace TestAssignment.PLL
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private OvenController _ovenController;

        [SerializeField] private float _cookingTime = 3f;
        [SerializeField] private float _burnoutTime = 10f;


        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _ovenController.Init(_cookingTime, _burnoutTime);
        }
    }
}
