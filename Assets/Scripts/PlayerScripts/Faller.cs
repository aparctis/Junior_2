using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Faller : MonoBehaviour
    {
        [SerializeField] Player_moves player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Flore")) player.ReportFlore();
        }

    }
}
