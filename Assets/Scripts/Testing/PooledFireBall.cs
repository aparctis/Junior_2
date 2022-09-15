using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class PooledFireBall : MonoBehaviour
    {
        private bool ready = false;

        //damage
        private float damage = 5f;
        private float maxDamage = 25f;
        private float velocity = 5;
        private float damageScale = 25;
        //size
        private float size = 0.2f;

        private bool gatDirection = false;
        public Vector3 defoultDirection;

        private bool isGrowing = true;
        private Rigidbody rb;


        //defoult setings
        private float defoultDamage;
        private float defoultVelocity;
        private float defoultSize;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            InitDefoultSetings();
        }

        private void OnEnable()
        {
            Debug.Log("Pooled fireball enable");
        }

        private void OnDisable()
        {
            ready = false;
            BackToDefoult();
        }

        void Update()
        {
            if (isGrowing) PowerUp();
            transform.localScale = new Vector3(size, size, size);
        }

        private void PowerUp()
        {
            if (damage < maxDamage)
            {

                damage += damageScale * Time.deltaTime;
                velocity = damage;
                if (size < 1f)
                {
                    size += Time.deltaTime;
                }
            }

            else
            {
                if (gatDirection)
                {
                    Fire(defoultDirection);
                }

                else
                {
                    Fire(transform.right);
                }
            }
        }

        public void SetDirection(Vector3 direction)
        {
            defoultDirection = direction;
            gatDirection = true;
            isGrowing = true;
        }

        public void Fire(Vector3 direction)
        {
            ready = true;
            rb.useGravity = true;
            isGrowing = false;
            rb.AddForce(direction * velocity);

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (ready)
            {
                if (collision.gameObject.GetComponent<Distructuble>() != null)
                {
                    collision.gameObject.GetComponent<Distructuble>().GetDamage(damage);
                }

                Debug.Log(collision.gameObject.tag /*+ ". Damsge -  " + damage + ". Size - " + size*/);

                gameObject.SetActive(false);
            }
        }


        //for pool
        private void InitDefoultSetings()
        {
            defoultDamage = damage;
            defoultVelocity = velocity;
            defoultSize = size;
        }

        private void BackToDefoult()
        {
            size = defoultSize;
            damage = defoultDamage;
            velocity = defoultVelocity;
        }
    }
}
