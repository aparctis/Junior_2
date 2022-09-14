using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class GroundChecker : MonoBehaviour
    {
        private bool m_onFlore;
        public bool onFlore => m_onFlore;

        //if player has rb, he can gat damage by the falling down
        [SerializeField] private bool hasRB;
        [SerializeField] Rigidbody rb;
        [SerializeField] private Player_moves player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Flore"))
            {
                m_onFlore = true;
                if (hasRB && rb != null)
                {
                    Debug.Log("Velocity - " + rb.velocity.y);
                    player.OnFlore(rb.velocity.y);
                }

            }

            else
            {
                m_onFlore = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Flore"))
            {
                m_onFlore = false;
                player.OnAir();
            }
        }
    }

}