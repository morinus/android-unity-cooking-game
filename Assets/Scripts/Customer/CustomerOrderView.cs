using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssignment
{
    public class CustomerOrderView : MonoBehaviour
    {
        [SerializeField] private Image _fillBarImage;
        [SerializeField] private Transform _orderTransform;
        [SerializeField] private float _timeToServeOrder = 30f;

        private Dictionary<OrderType, GameObject> _ordersDictionary;

        private float _timeElapsed = 0f;
        private int _maxNumberOfOrders = 2;

        private void OnEnable()
        {
            _fillBarImage.fillAmount = 1f;
            _timeElapsed = 0f;

            if (_ordersDictionary == null)
            {
                _ordersDictionary = new Dictionary<OrderType, GameObject>();
            }

            CreateRandomOrders();
        }

        private void OnDisable()
        {
            foreach (var key in _ordersDictionary.Keys)
            {
                Destroy(_ordersDictionary[key]);
            }

            _ordersDictionary.Clear();
        }

        private void Update()
        {
            _timeElapsed += Time.deltaTime;

            _fillBarImage.fillAmount = 1f - (_timeElapsed / _timeToServeOrder);

            if (_timeElapsed >= _timeToServeOrder)
            {
                this.gameObject.SetActive(false);
            }
        }

        private void CreateRandomOrders()
        {
            //var numberOfOrders = Random.Range(0, _maxNumberOfOrders) + 1;

            //for (int i = 0; i < numberOfOrders; ++i)
            //{
            //    var orderType = (OrderType)(Random.Range(0, GameController.Singleton.OrderPrefabs.Length));
            //    var orderPrefab = GameController.Singleton.OrderPrefabs[(int)orderType];
            //    var orderObject = Instantiate(orderPrefab, _orderTransform);

            //    _ordersDictionary.Add(orderType, orderObject);
            //}
        }
    }
}
