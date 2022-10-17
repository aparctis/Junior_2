using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class AdviceCaller : MonoBehaviour
    {
        [SerializeField] private int MainMenuAdviceIndex;
        [SerializeField] private bool withDelay = false;
        [SerializeField] private float delay = 1.0f;
        private bool callAble = true;

        private void Call()
        {
            MainMenu.singletonMenu.CallAdvice(MainMenuAdviceIndex);
            callAble = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (callAble)
            {
                if (other.gameObject.tag.Equals("Player"))
                {
                    if (withDelay)
                    {
                        Invoke("Call", delay);
                    }

                    else
                    {
                        Call();
                    }

                }
            }

        }


    }
}
