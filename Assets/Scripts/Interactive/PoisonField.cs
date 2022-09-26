using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class PoisonField : MonoBehaviour
    {
        private PlayerController player;

        [SerializeField]private float damagePerSecond = 5.0f;

        private float timer = 1.0f;
        private float second = 1.0f;

        private bool playerIsHere = false;
        void FixedUpdate()
        {
            if (playerIsHere&&player!=null)
            {
                timer -= Time.fixedDeltaTime;
                if (timer <= 0)
                {
                    player.GetDamage(damagePerSecond);
                    timer = second;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag.Equals("Player"))
            {
                player = other.gameObject.GetComponent<PlayerController>();
                playerIsHere = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                player = null;
                playerIsHere = false;
            }
        }


    }
}
