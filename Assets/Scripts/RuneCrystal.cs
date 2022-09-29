using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class RuneCrystal : MonoBehaviour
    {
        [SerializeField] private WeaponeType type;

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<PlayerController>().AddCrystal();
                gameObject.SetActive(false);
            }
        }
    }
}
