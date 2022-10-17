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

        private AudioSource source;

        //UI
        [SerializeField] private Button but_fire;
        [SerializeField] private Button but_water;
        [SerializeField] private Button but_wind;
        [SerializeField] private Button but_earth;

        private Image im_fire;
        private Image im_water;
        private Image im_wind;
        private Image im_earth;

        //Button Amount
        public float amountFire = Mathf.Clamp01(1);
        public float amountWater = Mathf.Clamp01(1);
        public float amountEarth = Mathf.Clamp01(1);
        public float amountWind = Mathf.Clamp01(1);





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
        [SerializeField] AudioClip fireballLounchSound;


        //cooldown
        private float fireball_coolDown = 2.0f;
        private float currentCoolDown_fireball = 0f;
        private bool onCoolDown_fire = false;


        //Rune parts
        private int runeCount_fire = 0;
        private int runeCount_earth = 0;
        private int runeCount_wind = 0;
        private int runeCount_water = 0;


        #region Unity Events
        void Start()
        {
            atackDirection = Vector3.right;

            //initialize buttons images
            InitButtons();

            source = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            CoolDown_fire();

            //UI update
            ButtonsAmountUpdate();
        }
        #endregion

        public void NewRune(WeaponeType type)
        {
            switch (type)
            {
                case WeaponeType.fire:
                    fireAble = true;
                    ButtonCheck();

                    CoolDownStart_fire();
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
                amountFire += (Time.deltaTime/fireball_coolDown);

                if (currentCoolDown_fireball <= 0)
                {
                    Reload_fire();
                }
            }
        }

        private void CoolDownStart_fire()
        {
            but_fire.interactable = false;
            amountFire = 0;
            im_fire.fillAmount = amountFire;
            onCoolDown_fire = true;
            currentCoolDown_fireball = fireball_coolDown;


        }

        private void Reload_fire()
        {
            onCoolDown_fire = false;
            currentCoolDown_fireball = fireball_coolDown;
            but_fire.interactable = true;


        }



        //imidiate atack
        public void FireBall_Atack()
        {
            if (fireAble)
            {

                if (onCoolDown_fire == false)
                {
                    anim.SetTrigger("spell_fire");
                    CoolDownStart_fire();

                }
            }
        }

        public void Fireball_forInvoke()
        {
            CheckAtackDirection();
            proj = Instantiate(fireball_, castPoint.position, Quaternion.identity) as GameObject;
            proj.GetComponent<Fireball_imidiate>().Fire(atackDirection);

            //sound of fireball
            source.clip = fireballLounchSound;
            source.Play();

        }


        //buttons and UI
        private void InitButtons()
        {
            im_fire = but_fire.image;
            im_water = but_water.image;
            im_earth = but_earth.image;
            im_wind = but_wind.image;

        }

        private void ButtonsAmountUpdate()
        {
            im_fire.fillAmount = amountFire;
            im_earth.fillAmount = amountEarth;
            im_water.fillAmount = amountWater;
            im_wind.fillAmount = amountWind;
        }



    }
}
