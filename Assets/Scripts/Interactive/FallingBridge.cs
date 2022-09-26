using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class FallingBridge : ActionCaller
    {
        private bool startRotate = false;

        void Start()
        {
            InitButton(StartRotate);
        }

        void FixedUpdate()
        {
            if (startRotate)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.fixedDeltaTime);

            }

        }


        public void StartRotate()
        {
            startRotate = true;
        }
    }
}
