using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class FloatingStatus : MonoBehaviour
    {
        [SerializeField] private FloatingPlatform FloatingPlatform;

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag.Equals("Player"))
            {
                FloatingPlatform.PlayerEnter();

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                FloatingPlatform.PlayerExit();

            }
        }
    }
}
