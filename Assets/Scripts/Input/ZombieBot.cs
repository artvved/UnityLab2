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
        
        [SerializeField] private Transform _zombie;
        private Transform _player;
        private bool canChangeDirection = true;
        private Vector3 direction = Vector3.zero;
        public bool IsAware { get; set; } = false;

       

        public override (Vector3 moveDirection, Quaternion viewDirection, bool shoot) CurrentInput()
        {
            if (!IsAware)
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
            IsAware = true;
            _player = transform;
        }

        public void Disaware()
        {
            IsAware = false;
        }

        private IEnumerator WaitAndChangeDirection()
        {
            canChangeDirection = false;
            yield return new WaitForSeconds(2);
            canChangeDirection = true;
        }
    }
}