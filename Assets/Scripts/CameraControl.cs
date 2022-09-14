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


        private void Awake()
        {
            cameraDistance = transform.position.z;
            defaultSpeed = cameraMoveSpeed;
        }

        private void FixedUpdate()
        {
            Vector3 newPos = new Vector3(playerTracker.position.x, playerTracker.position.y, cameraDistance);

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

            float x = (playerTracker.position.x - transform.position.x);
            float y = (playerTracker.position.y - transform.position.y);

            float sqd = (x * x) + (y * y);

            ofset = Mathf.Sqrt(sqd);
        }

    }
}
