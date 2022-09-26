using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class AtackZone : MonoBehaviour
    {
        [SerializeField] RatMover mover;

        private PlayerController player;
        private bool playerAble = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                mover.AtackReady();
                player = other.gameObject.GetComponent<PlayerController>();
                playerAble = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                mover.SetTarget(other.transform);
                player = null;
                playerAble = false;
            }
        }

        public void DamagePlayer(float damage)
        {
            if (playerAble)
            {
                if (player != null)
                {
                    player.GetDamage(damage);
                }
            }
        }
    }
}
