using UnityEngine;

namespace TestAssignment
{
    public class OrderView : MonoBehaviour
    {
        public void ActivateCheckmarkObject()
        {
            var childrenCount = this.transform.childCount;

            for (int i = 0; i < childrenCount; ++i)
            {
                var child = this.transform.GetChild(i);

                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
        }
    }
}
