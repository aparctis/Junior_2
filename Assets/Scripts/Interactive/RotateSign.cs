using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JuniorProject_01
{
    public class RotateSign : ActionCaller
    {
        [SerializeField] private int signID;

        [SerializeField] private int rotatedTimes;
        private bool isRotating = true;
        private float curentAngle;

        //light
        [SerializeField]private Light light;


        //Hiden Cave
        [SerializeField] private HidenCave cave;

        void Start()
        {
            StartAngle();
            curentAngle = 90f * rotatedTimes;
            InitButton(NewRotate);
            light.enabled = false;

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateRotation();

        }

        private void StartAngle()
        {
            float angle = 90f * rotatedTimes;
            transform.localRotation = Quaternion.Euler(0, 0, angle);

        }

        private void UpdateRotation()
        {
            if (isRotating)
            {
                curentAngle = 90f * rotatedTimes;

                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, curentAngle), Time.fixedDeltaTime);

            }

        }

        private void RightPosition()
        {
            light.enabled = true;
            cave.SignChange(signID, 1);

        }

        private void WrongPosition()
        {
            light.enabled = false;

            cave.SignChange(signID, 0);

        }

        public void NewRotate()
        {
            rotatedTimes++;

            if (rotatedTimes == 4)
            {
                Invoke("RightPosition", 1f);
            }
            else
            {
                Invoke("WrongPosition", 1f);
            }
        }

    }
}
