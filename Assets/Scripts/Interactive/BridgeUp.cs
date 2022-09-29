using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JuniorProject_01
{
    public class BridgeUp : ActionCaller
    {
        [SerializeField] private Transform upPosition;
        private bool startMove = false;
        private float speed = 2f;

        //Able/disable camera chenge ciew function
        [SerializeField] private bool changengeViewForAction = false;
        [SerializeField] private float changeViewActionDelay = 1.5f;
        [SerializeField] private float changeViewTime = 3.5f;

        private void Start()
        {
            InitButton(StartMove);
        }

        void FixedUpdate()
        {
            if (startMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, upPosition.position, speed * Time.fixedDeltaTime);
            }
        }

        public void StartMove()
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
            startMove = true;

        }

    }
}
