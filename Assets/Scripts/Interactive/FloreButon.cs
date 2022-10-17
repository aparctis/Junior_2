using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JuniorProject_01
{
    public class FloreButon : MonoBehaviour
    {
        //position when it`s pushed down (platform_2), and pushed up (platform)
        [SerializeField] private Transform platform_2;
        private Vector3 posUp;
        private Vector3 posDown;

        [SerializeField] private float moveSpeed = 2f;
        //0 = don`tMove; 1 = move down; 2 = moveUp
        private int moveStatus = 0;

        public Action pressAction;

        private bool isReadyToUse = true;
        [SerializeField]private float buttonCooldown = 5.0f;
        private float defoultCooldown;




        #region Unity events
        void Start()
        {
            //positions initialization
            posUp = transform.position;
            posDown = platform_2.position;

            //set defoult cooldown
            defoultCooldown = buttonCooldown;
        }

        void FixedUpdate()
        {
            MoveUpdate();
            CooldownTimer();
        }
        #endregion

        private void MoveUpdate()
        {
            switch (moveStatus)
            {
                case 0:

                    break;
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, posDown, moveSpeed * Time.fixedDeltaTime);
                    if (transform.position == posDown)
                    {
                        DownAction();
                        moveStatus = 2;

                    }
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, posUp, (moveSpeed/2) * Time.fixedDeltaTime);
                    if (transform.position == posUp)
                    {
                        moveStatus = 0;
                    }
                    break;
            }
        }

        private void DownAction()
        {
            if (pressAction != null)
            {
                pressAction.Invoke();
            }

            else
            {
                Debug.Log("Button has no action");

            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player")&&isReadyToUse)
            {
                if (moveStatus == 0)
                {
                    moveStatus = 1;
                }
            }
        }


        public void InitializeAction(Action a)
        {
            pressAction = a;
        }

        private void CooldownTimer()
        {
            if (!isReadyToUse)
            {
                buttonCooldown -= Time.fixedDeltaTime;
                if (buttonCooldown <= 0)
                {
                    buttonCooldown = defoultCooldown;
                    isReadyToUse = true;
                }
            }
        }

    }
}
