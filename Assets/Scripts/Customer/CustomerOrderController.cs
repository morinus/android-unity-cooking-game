using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestAssignment
{
    public class CustomerOrderController : MonoBehaviour
    {
        [SerializeField] private Image _fillBarImage;
        [SerializeField] private Transform _orderParentTransform;

        private List<Order> _orders;

        private int _ordersCompleted = 0;
        private int _totalOrders = 0;

        private float _timeElapsed = 0f;
        private float _timeToCompleteOrder = 0f;


        public bool TryToCompleteOrder(OrderType orderType)
        {
            foreach (var order in _orders)
            {
                if (order.IsCompleted)
                {
                    continue;
                }

                if (order.OrderType == orderType)
                {
                    order.OrderGameObject.GetComponent<OrderView>().ActivateCheckmarkObject();
                    order.IsCompleted = true;

                    _ordersCompleted++;

                    var isEverythingCompleted = _ordersCompleted == _totalOrders;
                    if (isEverythingCompleted)
                    {
                        GameController.Singleton.IncreasePlayerScore();

                        this.gameObject.SetActive(false);
                    }

                    return true;
                }
            }

            return false;
        }

        private void OnEnable()
        {
            if (_timeToCompleteOrder == 0f)
            {
                _timeToCompleteOrder = GameController.Singleton.LevelData.TimeToServeCustomer;
            }

            CreateOrders();
        }

        private void OnDisable()
        {
            DestroyOrders();
        }

        private void Update()
        {
            _timeElapsed += Time.deltaTime;
            _fillBarImage.fillAmount = 1f - (_timeElapsed / _timeToCompleteOrder);

            if (_timeElapsed >= _timeToCompleteOrder)
            {
                this.gameObject.SetActive(false);
            }
        }

        private void CreateOrders()
        {
            if (_orders == null)
            {
                _orders = new List<Order>();
            }

            _orders.Clear();

            var maxNumberOfOrders = GameController.Singleton.LevelData.MaxNumberOfOrders;
            var recipes = GameController.Singleton.LevelData.Recipes;

            for (int i = 0; i < maxNumberOfOrders; ++i)
            {
                var randomRecipe = recipes[Random.Range(0, recipes.Length)];
                var orderGameObject = Instantiate(randomRecipe.RecipePrefab, _orderParentTransform);

                _orders.Add(new Order(randomRecipe.OrderType, orderGameObject));
            }

            _ordersCompleted = 0;
            _timeElapsed = 0f;
            _totalOrders = maxNumberOfOrders;
        }

        private void DestroyOrders()
        {
            foreach (var order in _orders)
            {
                Destroy(order.OrderGameObject);

            }
        }
    }
}
