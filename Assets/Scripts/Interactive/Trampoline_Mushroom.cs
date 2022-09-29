using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Trampoline_Mushroom : MonoBehaviour
    {
        //animation
        [SerializeField] Animator anim;

        //jump force
        private int velocityModifyer = 1100;
        [SerializeField]private float maxJumpForce = 20000.0f;
        private float minJumpForce = 7000.0f;

        private float currentForce;

        private Rigidbody playerRB = null;
        private Player_moves mover = null;

        private void StartAnimation()
        {
            anim.SetTrigger("jump");
        }

        private void ResetProps()
        {
            mover = null;
            playerRB = null;
            currentForce = 0;
        }

        public void Lounch()
        {
            if (playerRB != null)
            {
                playerRB.AddForce(Vector3.up * currentForce);
                mover.OnAir();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<PlayerController>().damageAble = false;
                playerRB = other.gameObject.GetComponent<Rigidbody>();
                mover = other.gameObject.GetComponent<Player_moves>();

                currentForce = -(playerRB.velocity.y * velocityModifyer);
                if (currentForce > maxJumpForce) currentForce = maxJumpForce;
                if(currentForce>minJumpForce) StartAnimation();

            }
        }


        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<PlayerController>().damageAble = true;
                ResetProps();
            }

        }

    }
}
