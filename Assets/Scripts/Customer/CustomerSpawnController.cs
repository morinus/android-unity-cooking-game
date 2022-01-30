using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment
{
    public class CustomerSpawnController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _customersList;

        private float _timeBetweenSpawns = 0f;
        private float _timeElapsed = 0f;


        public void Init(float timeBetweenSpawns)
        {
            _timeBetweenSpawns = timeBetweenSpawns;
        }

        private void Update()
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= _timeBetweenSpawns)
            {
                SpawnCustomer();

                _timeElapsed = 0f;
            }
        }

        private void SpawnCustomer()
        {
            var availableCustomers = _customersList.FindAll((customer) => !customer.activeSelf);

            var hasAvailableCustomer = availableCustomers.Count > 0;
            if (hasAvailableCustomer)
            {
                var randomCustomer = availableCustomers[Random.Range(0, availableCustomers.Count)];
                randomCustomer.SetActive(true);
            }
        }
    }
}
