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


        //animations
        [SerializeField] private Animator anim;
        private bool isRuning = false;

        //RidgidBody
        [HideInInspector]public Rigidbody rb;
        
        [SerializeField] private float jumpForce = 11000;

        //NoRB
        [SerializeField] private float moveSpeed = 10;

        private bool moveRight = false;
        private bool moveLeft = false;

        //player model
        [SerializeField] private GameObject model;

        //jumps
        private bool inAir = false;
        private int jumpsCount = 1;
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



        //walk with NO phisics
        public void WalkRight()
        {
            lookAtX = 1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (moveSpeed * Time.fixedDeltaTime));

            }
            if (!isRuning) isRuning = true;
        }
        public void WalkLeft()
        {
            lookAtX = -1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (-moveSpeed * Time.fixedDeltaTime));

            }
            if (!isRuning) isRuning = true;

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
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                WalkLeft();
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
            if (moveLeft)
            {
                WalkLeft();

            }
            else if (moveRight)
            {
                WalkRight();

            }

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
                        anim.SetTrigger("jump");

                    }

                    else
                    {

                        Vector3 jumpdirection = new Vector3(1, 2, 0).normalized;
                        rb.AddForce(jumpdirection * jumpForce);
                        anim.SetTrigger("jump");

                    }
                }

                else
                {
                    Debug.Log("Wall NOT found");

                    if (curentJumpCount > 1)
                    {
                        curentJumpCount--;
                        rb.AddForce(transform.up * jumpForce);
                        anim.SetTrigger("jump");

                    }
                }
            }

            else
            {
                curentJumpCount--;
                rb.AddForce(transform.up * jumpForce);
                anim.SetTrigger("jump");

            }
        }

        public void OnAir()
        {
            inAir = true;
            anim.SetTrigger("fly");
        }

        //Animation after falling
        public void OnFlore()
        {
            inAir = false;
            curentJumpCount = jumpsCount;
            anim.SetTrigger("land");


        }

        //Damage after falling
        public void ReportFlore()
        {
            float velocity = rb.velocity.y;


            if (velocity < velocityToDamage)
            {
                float damage = 0 - (velocity - velocityToDamage);
                player.GetDamage(damage);
            }
        }



    }

}