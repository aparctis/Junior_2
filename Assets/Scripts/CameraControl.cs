using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Transform playerTracker;
        private float cameraDistance;

        [SerializeField] private float cameraMoveSpeed = 5f;
        private float defaultSpeed;

        //distance from player, when camera movespeed is growing 
        private float maxOfset = 5;
        private float minOfset = 1;
        private float ofset;

        //switch camera move ability
        [SerializeField]private bool followPlayer = true;

        //singleton part
        public static CameraControl singleCamera;

        //change view
        private Transform currentTarget;
        private bool tmpTarget = false;
        private float tmpTimer = 0;

        [SerializeField] private Player_moves player_moves;


        private void Awake()
        {
            cameraDistance = transform.position.z;
            defaultSpeed = cameraMoveSpeed;
        }


        //Test 
        private void Start()
        {
            if (singleCamera == null) singleCamera = this;
            currentTarget = playerTracker;
        }

        private void FixedUpdate()
        {
            CameraMan();

            Vector3 newPos = new Vector3(currentTarget.position.x, currentTarget.position.y, cameraDistance);

            if (followPlayer)
            {
                OfsetCheck();

                //camera speed check
                if (ofset > minOfset)
                {
                    if(ofset>maxOfset)
                    {
                        cameraMoveSpeed++;
                    }
                    else
                    {
                        cameraMoveSpeed = defaultSpeed;
                    }

                    
                    transform.position = Vector3.MoveTowards(transform.position, newPos, cameraMoveSpeed * Time.fixedDeltaTime);
                }

            }

            else
            {
                transform.position = newPos;
            }

        }

        private void  OfsetCheck()
        {

            float x = (currentTarget.position.x - transform.position.x);
            float y = (currentTarget.position.y - transform.position.y);

            float sqd = (x * x) + (y * y);

            ofset = Mathf.Sqrt(sqd);
        }


        //View Change
        public void ViewChangeStart(Transform newViewTarget, float timeToLoock)
        {
            currentTarget = newViewTarget;
            tmpTimer = timeToLoock;
            tmpTarget = true;
            player_moves.moveAble = false;
        }

        private void ViewChangeOver()
        {
            currentTarget = playerTracker;
            player_moves.moveAble = true;
            tmpTarget = false;

        }

        private void CameraMan()
        {
            if (tmpTarget)
            {
                tmpTimer -= Time.fixedDeltaTime;
                if (tmpTimer <= 0)
                {
                    ViewChangeOver();
                }
            }
        }


    }
}
