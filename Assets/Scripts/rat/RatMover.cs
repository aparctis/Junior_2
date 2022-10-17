using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class RatMover : Distructuble
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject model;
        [SerializeField] private Collider col;

        private bool moveAble = true;

        //walk and run
        private float walkSpeed = 2.0f;
        private float runSpeed = 7.5f;
        private int lookAtX = 1;
        private float modelAngle = 0f;
        [SerializeField]private float patrolDistance = 3f;
        
        private float initX;
        private float maxX;
        private float minX;

        private bool patrolRight = true;

        //Wait
        private float waitTime = 3f;
        private float waitTimer;

        //atack
        [SerializeField] private AtackZone zone;
        private float damage = 15.0f;

        private Transform player;
        private float followOffset = 1.5f;
        private float atackCoolDown = 2f;
        private float coolDown;
        
        //UI and HP


        //action status
        private bool isAlive = true;

        /// <summary>
        /// 0 - wait/idle; 1 = patrol/walk; 2 = agresive/run; 3=agresive/atack
        /// </summary>
        private int activityStatus = 0;


        #region Unity Evets
        void Start()
        {
            InitPatrolArea();

            waitTimer = waitTime;

            coolDown = atackCoolDown;

            maxHP = heatPoints;
            UiUpdate();


        }


        void FixedUpdate()
        {
            //chacking model rotation
            RotateModel();

            ActionCheck();


        }
        #endregion


        public override void GetDamage(float damage)
        {
            Debug.Log("Rat damaged");

            if (isAlive)
            {
                heatPoints -= damage;
                UiUpdate();

                if (heatPoints <= 0)
                {
                    Death();
                }

                else
                {
                    Hit();
                }
            }




        }
        private void RotateModel()
        {
            if (lookAtX == 1) modelAngle = 0;
            else modelAngle = 180;
            model.transform.localRotation = new Quaternion(0, modelAngle, 0, 0);
        }


        //Actions
        private void WalkRight()
        {
            lookAtX = 1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (walkSpeed * Time.fixedDeltaTime));

            }

            if (anim.GetBool("walk") == false) anim.SetBool("walk", true);

        }
        private void WalkLeft()
        {
            lookAtX = -1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (-walkSpeed * Time.fixedDeltaTime));

            }
            if (anim.GetBool("walk") == false) anim.SetBool("walk", true);

        }

        private void RunRight()
        {
            lookAtX = 1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (runSpeed * Time.fixedDeltaTime));

            }

            if (anim.GetBool("run") == false) anim.SetBool("run", true);

        }
        private void RunLeft()
        {
            lookAtX = -1;
            if (moveAble)
            {
                transform.Translate(Vector3.right * (-runSpeed * Time.fixedDeltaTime));

            }
            if (anim.GetBool("run") == false) anim.SetBool("run", true);

        }

        public void Atack()
        {
            anim.SetBool("walk", true);
        }

        private void Death()
        {
            anim.SetTrigger("death");
            rb.isKinematic = true;
            col.enabled = false;
            isAlive = false;
            moveAble = false;

        }

        private void Hit()
        {
            anim.SetTrigger("hit");

        }

        // intellect

        private void InitPatrolArea()
        {
            initX = transform.position.x;

            maxX = initX + patrolDistance;
            minX = initX - patrolDistance;
        }

        private void ActionCheck()
        {
            if (isAlive)
            {
                switch (activityStatus)
                {
                    case 0:
                        Wait();
                        break;

                    case 1:
                        Patrol();
                        break;
                    case 2:
                        FollowPlayer();
                        break;
                    case 3:
                        AtackPlayer();
                        break;
                }
            }



        }

        private void Patrol()
        {
            if (patrolRight)
            {
                WalkRight();
                if (transform.position.x > maxX)
                {
                    activityStatus = 0;
                    patrolRight = false;
                }
            }
            else
            {
                WalkLeft();
                if (transform.position.x < minX)
                {
                    activityStatus = 0;
                    patrolRight = true;
                }
            }


        }

        private void Wait()
        {
            if (anim.GetBool("walk") != false) anim.SetBool("walk", false);
            if (anim.GetBool("run") != false) anim.SetBool("run", false);

            waitTimer -= Time.fixedDeltaTime;
            if (waitTimer < 0)
            {
                activityStatus = 1;
                waitTimer = waitTime;
            }
        }

        //atack logic
        public void SetTarget(Transform target)
        {
            player = target;
            activityStatus = 2;
        }

        private void FollowPlayer()
        {
            if (player != null)
            {
                if (transform.position.x < (player.position.x-followOffset))
                {
                    RunRight();
                }

                else if(transform.position.x > (player.position.x + followOffset))
                {
                    RunLeft();
                }

                else
                {
                    if (anim.GetBool("walk") != false) anim.SetBool("walk", false);
                    if (anim.GetBool("run") != false) anim.SetBool("run", false);

                    if (player.position.x > transform.position.x)
                    {
                        lookAtX = 1;

                    }
                    else
                    {
                        lookAtX = -1;

                    }
                }
            }
            else
            {
                Debug.LogError("rat has no target!");
            }
        }

        public void AtackReady()
        {
            if (anim.GetBool("walk") != false) anim.SetBool("walk", false);
            if (anim.GetBool("run") != false) anim.SetBool("run", false);

            activityStatus = 3;
            coolDown = 0;

            Debug.Log("Atack!");
            Debug.Log(activityStatus);

        }

        private void AtackPlayer()
        {
            coolDown -= Time.fixedDeltaTime;
            if (coolDown <= 0)
            {
                anim.SetTrigger("atack");
                coolDown = atackCoolDown;
            }
        }

        public void DamagePlayer()
        {
            zone.DamagePlayer(damage);
        }

        //UI

        internal virtual void UiUpdate()
        {
            if (hpSlider != null)
            {

                float newHP = (hpSlider.maxValue / maxHP) * heatPoints;
                hpSlider.value = newHP;


            }

        }

    }
}
