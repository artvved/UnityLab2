using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using Search;
using UnityEngine;

public class NoticeCollider : MonoBehaviour
{
    [SerializeField] private ZombieBot zombie;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.GetComponentInParent<Player>() != null)
        {
           
            zombie.Aware(other.transform);
        }
    }

  

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>() != null)
        {
            
            zombie.Disaware();
        }
    }
}