using UnityEngine;

namespace TestAssignment
{
    public class Order
    {
        public OrderType OrderType;
        public GameObject OrderGameObject;

        public Order(OrderType orderType, GameObject orderGameObject)
        {
            OrderType = orderType;
            OrderGameObject = orderGameObject;
        }
    }
}