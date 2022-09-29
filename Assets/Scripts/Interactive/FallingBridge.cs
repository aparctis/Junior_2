using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class FallingBridge : ActionCaller
    {

        private bool startRotate = false;

        private bool isOpen = false;

        //Able/disable camera chenge ciew function
        [SerializeField] private bool changengeViewForAction = false;
        [SerializeField] private float changeViewActionDelay = 1.5f;
        [SerializeField] private float changeViewTime = 3.5f;

        void Start()
        {
            InitButton(StartRotate);
        }

        void FixedUpdate()
        {
            if (startRotate)
            {
                if (isOpen)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.fixedDeltaTime);

                    if (transform.eulerAngles.z > 359)
                    {
                        startRotate = false;
                        isOpen = false;
                    }
                }

                else
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.fixedDeltaTime);

                    if (transform.eulerAngles.z < 271)
                    {
                        startRotate = false;
                        isOpen = true;
                    }
                }

            }

        }


        public void StartRotate()
        {
            if (changengeViewForAction)
            {

                CameraControl.singleCamera.ViewChangeStart(gameObject.transform, changeViewTime);
                Invoke("Action", changeViewActionDelay);

            }

            else
            {
                Action();
            }
        }

        private void Action()
        {
            startRotate = true;

        }
    }
}
