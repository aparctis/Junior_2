using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Altar : MonoBehaviour
    {
        [SerializeField] private GameObject runeAnimation;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                if (collision.gameObject.GetComponent<PlayerController>().allRunesCollected)
                {
                    collision.gameObject.GetComponent<PlayerController>().ActivateRune();
                    if (runeAnimation != null)
                    {
                        runeAnimation.SetActive(true);
                    }
                }
            }
        }

    }
}
