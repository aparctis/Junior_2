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

        private bool isGrounded;
        public LayerMask Flore;

        private void Update()
        {
            GroundChack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Flore"))
            {
                m_onFlore = true;
                if (hasRB && rb != null)
                {
                    player.OnFlore();

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
                if (!isGrounded)
                {
                    player.OnAir();

                }

                //Invoke("GroundCheck", 0.1f);
            }
        }



        private void GroundChack()
        {
            isGrounded = Physics.CheckSphere(transform.position, 0.2f, Flore);  
        }
    }

}