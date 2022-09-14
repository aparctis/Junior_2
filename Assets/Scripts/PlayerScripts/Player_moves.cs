using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Player_moves : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        public bool moveAble = true;
        //if player falls
        [SerializeField] private float velocityToDamage = 25f;


        //RidgidBody
        [HideInInspector]public Rigidbody rb;
/*        [SerializeField] private float thrust;
*/        
        [SerializeField] private float jumpForce = 11000;

        //NoRB
        [SerializeField] private float moveSpeed = 10;

        private bool moveRight = false;
        private bool moveLeft = false;

        //player model
        [SerializeField] private GameObject model;

        //jumps
        private bool inAir = false;
        private int jumpsCount = 2;
        private int curentJumpCount;

        [SerializeField] private WallChecker wallChecker;

        //Rotation 
        private int lookAtX = 1;
        public int lookDirectionX => lookAtX;
        private float modelAngle = 0;

        //Unity Events
        void Start()
        {
            if(GetComponent<Rigidbody>()!=null)
            {
                rb = GetComponent<Rigidbody>();

            }

            curentJumpCount = jumpsCount;
            moveAble = true;
        }

        void FixedUpdate()
        {
            RotateModel();

            //check walking on touchscreen
            TouchCheck();

            //Chacking walk function on keyboard
            WalkControl_();

        }
        #region rotate

        private void RotateModel()
        {
            if (lookAtX == 1) modelAngle = 0;
            else modelAngle = 180;
            model.transform.localRotation = new Quaternion(0, modelAngle, 0, 0);
        }




        #endregion

        #region phisic walk(disable)
        //walk part (with rb)
        /*        private void GoRight()
                {
                    rb.AddForce(transform.right * thrust);
                }

                private void GoLeft()
                {
                    rb.AddForce(transform.right * -thrust);

                }*/
        #endregion

        //walk with NO phisics
        public void WalkRight()
        {
            lookAtX = 1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (moveSpeed * Time.fixedDeltaTime));

            }
        }
        public void WalkLeft()
        {
            lookAtX = -1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (-moveSpeed * Time.fixedDeltaTime));

            }
        }

        //DEBUG
        private void WalkControl_()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }



            //keyHold
            if (Input.GetKey(KeyCode.RightArrow))
            {
                WalkRight();
                //GoRight();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                WalkLeft();
                //GoLeft();
            }




        }


        //touchscreen
        #region touches
        public void RightDown()
        {
            moveRight = true;
        }

        public void RightUp()
        {
            moveRight = false;
        }

        public void LeftDown()
        {
            moveLeft = true;
        }

        public void LeftUp()
        {
            moveLeft = false;
        }


        private void TouchCheck()
        {
            if (moveLeft) WalkLeft();
            if (moveRight) WalkRight();
        }

        #endregion
        
        //JUMP
        public void Jump()
        {
            if (inAir)
            {
                Debug.Log("Wall check");
                if (wallChecker.WallJumpAble)
                {
                    Debug.Log("Wall found");

                    if (lookAtX > 0)
                    {

                        Vector3 jumpdirection = new Vector3(-1, 2, 0).normalized;
                        rb.AddForce(jumpdirection * jumpForce);

                    }

                    else
                    {

                        Vector3 jumpdirection = new Vector3(1, 2, 0).normalized;
                        rb.AddForce(jumpdirection * jumpForce);
                    }
                }

                else
                {
                    Debug.Log("Wall NOT found");

                    if (curentJumpCount > 0)
                    {
                        curentJumpCount--;
                        rb.AddForce(transform.up * jumpForce);
                    }
                }
            }

            else
            {
                curentJumpCount--;
                rb.AddForce(transform.up * jumpForce);
            }
        }

        public void OnAir()
        {
            inAir = true;
        }

        public void OnFlore(float velocity)
        {
            inAir = false;
            curentJumpCount = jumpsCount;

            if(velocity<velocityToDamage)
            {
                float damage = 0-(velocity - velocityToDamage);
                player.GetDamage(damage);
            }
        }



    }

}