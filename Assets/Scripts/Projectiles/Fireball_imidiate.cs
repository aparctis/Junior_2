using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Fireball_imidiate : Projectile
    {
        [SerializeField] private float damage = 25.0f;

        //if gat ridgitBody component
        [SerializeField] private float velocity;
        private Rigidbody rb;
        private bool gatRB = true; 

        //if not phisical obj
        private float speed = 25.0f;

        //for impact effect
        [SerializeField] private GameObject impact;
        [SerializeField] private bool gatImpactEffect = false;

        #region Unity Events
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }
        #endregion

        public void Fire(Vector3 direction)
        {


            if (gatRB)
            {
                rb.useGravity = true;
                rb.AddForce(direction.normalized * velocity);
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Distructuble>() != null)
            {
                collision.gameObject.GetComponent<Distructuble>().GetDamage(damage);
            }
            if (gatImpactEffect)
            {
                GameObject imp = Instantiate(impact) as GameObject;
                imp.transform.position = gameObject.transform.position;
            }

            Destroy(gameObject);
        }

    }
}
