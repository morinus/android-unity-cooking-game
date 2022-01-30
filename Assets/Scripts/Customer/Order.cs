using UnityEngine;

namespace TestAssignment
{
    public class Order
    {
        public OrderType OrderType;
        public GameObject OrderGameObject;
        public bool IsCompleted;

        public Order(OrderType orderType, GameObject orderGameObject)
        {
            OrderType = orderType;
            OrderGameObject = orderGameObject;
            IsCompleted = false;
        }
    }
}