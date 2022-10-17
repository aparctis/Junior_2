using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class PoisonField : MonoBehaviour
    {

        //Damage player
        private PlayerController player;
        private bool playerIsHere = false;

        //Damage rats
        private List<Distructuble> rats = new List<Distructuble>();


        [SerializeField]private float damagePerSecond = 5.0f;

        private float timer = 1.0f;
        private float second = 1.0f;

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

            if (rats.Count > 0)
            {
                timer -= Time.fixedDeltaTime;
                if (timer <= 0)
                {
                    foreach(Distructuble rat in rats)
                    {
                        rat.GetDamage(damagePerSecond);
                    }
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

            else if (other.gameObject.tag.Equals("Enemy"))
            {
                if (other.GetComponent<Distructuble>() != null)
                {
                    Distructuble rat = other.GetComponent<Distructuble>();
                    rats.Add(rat);

                }

                else
                {
                    Debug.Log("Enemy has no Distructuble");
                }
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                player = null;
                playerIsHere = false;
            }

            else if (other.gameObject.tag.Equals("Enemy"))
            {
                if (other.GetComponent<Distructuble>() != null)
                {
                    Distructuble rat = other.GetComponent<Distructuble>();
                    rats.Remove(rat);

                }

                else
                {
                    Debug.Log("Enemy has no Distructuble");
                }
            }
        }


    }
}
