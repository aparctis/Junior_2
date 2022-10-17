using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Altar : MonoBehaviour
    {
        [SerializeField] private GameObject runeAnimation;

        private bool wasntCall = true;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                if (other.gameObject.GetComponent<PlayerController>().allRunesCollected)
                {
                    if (wasntCall)
                    {
                        other.gameObject.GetComponent<PlayerController>().ActivateRune();
                        if (runeAnimation != null)
                        {
                            runeAnimation.SetActive(true);

                        }

                        Invoke("ActivationWithDelay", 1.0f);
                    }

                }
            }
        }

        private void ActivationWithDelay()
        {
            MainMenu.singletonMenu.CallAdvice(2);
            wasntCall = false;


        }

    }
}
