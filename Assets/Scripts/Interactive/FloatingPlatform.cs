using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class FloatingPlatform : MonoBehaviour
    {
        [SerializeField] private GameObject platform;

        private Vector3 upPos;
        [SerializeField] private Transform downPos;
        [SerializeField] private Transform floatPos;

        private float floatSpeed = 0.5f;
        private float flySpeed = 10.0f;
        private float fallSpeed = 3.0f;

        private bool isFloating = true;
        private bool floatDown = true;
        private bool flyDown = true;

        private void Start()
        {
            upPos = platform.transform.position;
        }

        void FixedUpdate()
        {
            if (isFloating) Floating();
            else
            {
                Flying();
            }
        }

        private void Floating()
        {
            if (floatDown)
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, floatPos.position, floatSpeed * Time.fixedDeltaTime);
                if (platform.transform.position == floatPos.position)
                {
                    floatDown = false;
                }
            }

            else
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, upPos, floatSpeed * Time.fixedDeltaTime);
                if (platform.transform.position == upPos)
                {
                    floatDown = true;

                }


            }
        }

        private void Flying()
        {
            if (flyDown)
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, downPos.position, fallSpeed * Time.fixedDeltaTime);
            }

            else
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, upPos, flySpeed * Time.fixedDeltaTime);
                if(platform.transform.position ==upPos)
                {
                    isFloating = true;
                    floatDown = true;
                    flyDown = true;
                }

            }
        }


        public void PlayerEnter()
        {
            isFloating = false;

        }

        public void PlayerExit()
        {
            flyDown = false;

        }



    }
}
