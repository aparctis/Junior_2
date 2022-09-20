using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace JuniorProject_01
{
    public class Player_Atacks : MonoBehaviour
    {
        [SerializeField] private Player_moves moves;
        [SerializeField] private Transform castPoint;

        [SerializeField] private Animator anim;


        [SerializeField] private Button but_fire;
        [SerializeField] private Button but_water;
        [SerializeField] private Button but_wind;
        [SerializeField] private Button but_earth;

        [SerializeField] private bool fireAble;
        [SerializeField] private bool waterAble;
        [SerializeField] private bool windAble;
        [SerializeField] private bool earthAble;

        private Vector3 atackDirection;
        [SerializeField] private float atackHigh;


        //FIRE
        private GameObject proj;
        [SerializeField] GameObject fireball_loading;
        [SerializeField] GameObject fireball_;


        //cooldown
        private float fireball_coolDown = 2.0f;
        private float currentCoolDown_fireball = 0f;
        private bool onCoolDown_fire = false;



        #region Unity Events
        void Start()
        {
            atackDirection = Vector3.right;

        }

        // Update is called once per frame
        void Update()
        {
            CoolDown_fire();
        }
        #endregion

        public void NewRune(WeaponeType type)
        {
            switch (type)
            {
                case WeaponeType.fire:
                    fireAble = true;
                    ButtonCheck();
                    break;
                case WeaponeType.water:
                    waterAble = true;
                    ButtonCheck();
                    break;
                case WeaponeType.earth:
                    earthAble = true;
                    ButtonCheck();
                    break;
                case WeaponeType.wind:
                    windAble = true;
                    ButtonCheck();
                    break;
            }

            ButtonCheck();
        }

        public void CheckAtackDirection()
        {
            atackDirection = new Vector3(moves.lookDirectionX, atackHigh, 0);
        }


        private void ButtonCheck()
        {
            but_fire.interactable = fireAble;
            but_water.interactable = waterAble;
            but_wind.interactable = windAble;
            but_earth.interactable = earthAble;

        }


        //Rune of FIRE part
        private void CoolDown_fire()
        {
            if (onCoolDown_fire)
            {
                currentCoolDown_fireball -= Time.deltaTime;
                if (currentCoolDown_fireball <= 0)
                {
                    Reload_fire();
                }
            }
        }

        private void CoolDownStart_fire()
        {
            but_fire.interactable = false;
            onCoolDown_fire = true;
        }

        private void Reload_fire()
        {
            onCoolDown_fire = false;
            currentCoolDown_fireball = fireball_coolDown;
            but_fire.interactable = true;


        }


        //Atack with loading
        public void FireBall_AtackDown()
        {
            CheckAtackDirection();
            moves.moveAble = false;
            if (fireAble)
            {
                proj = Instantiate(fireball_loading, castPoint.position, Quaternion.identity) as GameObject;
                proj.GetComponent<Fireball>().SetDirection(atackDirection);
            }
        }

        public void FireBall_AtackUp()
        {
            moves.moveAble = true;

            if (fireAble)
            {
                if (proj != null && proj.GetComponent<Fireball>() != null)
                {
                    proj.GetComponent<Fireball>().Fire(atackDirection);

                }
            }
        }

        //imidiate atack
        public void FireBall_Atack()
        {
            if (onCoolDown_fire == false)
            {
                anim.SetTrigger("spell_fire");

                Invoke("Fireball_forInvoke", 0.2f);
            }


        }

        private void Fireball_forInvoke()
        {
            CheckAtackDirection();
            proj = Instantiate(fireball_, castPoint.position, Quaternion.identity) as GameObject;
            proj.GetComponent<Fireball_imidiate>().Fire(atackDirection);
            CoolDownStart_fire();
        }

    }
}
