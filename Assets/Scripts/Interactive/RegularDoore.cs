using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class RegularDoore : ActionCaller
    {
        private bool startRotate = false;

        private bool isOpen = false;

        [SerializeField] private float openY;

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
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, openY, 0), Time.fixedDeltaTime);


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
