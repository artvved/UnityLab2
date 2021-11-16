using System;
using System.Collections;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Search
{
    public class ZombieBot : PlayerInput
    {
        [SerializeField] private ZombieComponent _zombieComponent;
        private Transform _zombie;
        private Transform _player;
        private bool canChangeDirection = true;
        private Vector3 direction = Vector3.zero;

        private void Awake()
        {
            _zombie = _zombieComponent.transform;
        }

        public override (Vector3 moveDirection, Quaternion viewDirection, bool shoot) CurrentInput()
        {
            if (!_zombieComponent.IsAware)
            {
                return (Vector3.zero, _zombie.rotation, false);
            }

            if (canChangeDirection)
            {
                var x = _player.right.x;
                var z = _player.right.z;
                var deltax = Random.Range(-x, x);
                var deltaz = Random.Range(-z, z);

                direction = _player.forward + new Vector3(deltax, 0, deltaz);

                StartCoroutine(WaitAndChangeDirection());
            }

            return (direction, Quaternion.LookRotation(direction), false);
        }


        public void Aware(Transform transform)
        {
            _zombieComponent.IsAware = true;
            _player = transform;
        }

        public void Disaware()
        {
            _zombieComponent.IsAware = false;
        }

        private IEnumerator WaitAndChangeDirection()
        {
            canChangeDirection = false;
            yield return new WaitForSeconds(2);
            canChangeDirection = true;
        }
    }
}