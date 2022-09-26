using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class LoockZone : MonoBehaviour
    {
        [SerializeField] RatMover mover;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                mover.SetTarget(other.transform);
            }
        }

    }
}
