using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace JuniorProject_01
{
    public enum WeaponeType { fire, earth, water, wind}
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player_moves moves;


        //stats
        private float curentHeatPoints;
        [SerializeField] private float maxHeatPoints = 100;
        [SerializeField ]private int lives = 1;
        private bool m_Alive = true;
        public bool isAlive => m_Alive;


        //bonus shield
        private bool gatShield = false;
        private float shieldTime = 0f;
        private float resist = 0f;
        private float maxResist = 0.9f;
        [SerializeField] private GameObject shieldObject;

        //UI
        [SerializeField]private Slider _hpSlider;

        //death and respawn
        public bool damageAble = true;

        private Vector3 checkPoint;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject levelDoneScreen;

        //magic
        [SerializeField] private Player_Atacks atack;

        private int runeCollectedOnLevel;
        [SerializeField] int haveToCollect = 3;
        [SerializeField] WeaponeType runeTypeOnLevel;
        [SerializeField] private TextMeshProUGUI runeText;
        [HideInInspector] public bool allRunesCollected = false;


        //Animations (hit)
        [SerializeField] private Animator anim;

        //Advices on Level
        private bool advicesAble = true;
        private bool startAdvice = true;
        [SerializeField]private float adviceDelay = 2f;

        private void Start()
        {

            checkPoint = transform.position;
            curentHeatPoints = maxHeatPoints;

            HpSliderUpdate();

            //checking if player gat shield
            if (!gatShield) shieldObject.SetActive(false);
            else shieldObject.SetActive(true);


            //adice
            if (advicesAble&&startAdvice)
            {
                Invoke("StartAdvice", adviceDelay);
                    
            }
            else
            {
                Debug.Log("No advices");
            }
        }

        private void Update()
        {
            ShieldTimer();
        }


        //Weapones & atack

        public void ActivateRune()
        {
            if (runeCollectedOnLevel == haveToCollect)
            {
                atack.NewRune(runeTypeOnLevel);
            }
        }

        public void AddCrystal()
        {
            runeCollectedOnLevel++;
            RuneTextUpdate();
            if (runeCollectedOnLevel == haveToCollect)
            {
                MainMenu.singletonMenu.CallAdvice(1);
                allRunesCollected = true;
            }
        }

        private void RuneTextUpdate()
        {
            runeText.text = ("x " + runeCollectedOnLevel + "/3");
        }


        //hp and damage
        public void GetDamage(float damage)
        {
            if (isAlive)
            {
                if (damageAble)
                {
                    Debug.Log("GetDamage: " + damage);

                    ShieldCheck(damage);
                    if (curentHeatPoints <= 0) Death();
                    HpSliderUpdate();
                    anim.SetTrigger("hit");
                }

                else
                {
                    Debug.Log("NOT GetDamage: " + damage);

                }

            }
        }

        public void Heal(float heal)
        {
            curentHeatPoints += heal;
            if (curentHeatPoints > maxHeatPoints) curentHeatPoints = maxHeatPoints;
            HpSliderUpdate();

        }

        private void Death()
        {
            anim.SetBool("isDead", true);
            anim.SetTrigger("dye");
            m_Alive = false;
            lives--;
            if (lives <= 0)
            {
                GameOver();
            }

            else
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            curentHeatPoints = maxHeatPoints;
            transform.position = checkPoint;
            anim.SetBool("isDead", false);
            m_Alive = true;


        }

        //bonuses
        public void GetShield(float shieldResist, float bonustime)
        {
            if (gatShield == false)
            {
                gatShield = true;
                resist = shieldResist;
                shieldTime = bonustime;
            }

            else
            {
                shieldTime += bonustime;
                if (shieldResist > resist)
                {
                    resist = shieldResist;
                }
            }
        }

        private void ShieldCheck(float clearDamage)
        {
            if (gatShield)
            {
                float trueDamage = clearDamage - (clearDamage * resist);
                curentHeatPoints -= trueDamage;

                BloodScreen.singleton.Bleed(trueDamage);
            }
            else
            {
                curentHeatPoints -= clearDamage;
                BloodScreen.singleton.Bleed(clearDamage);

            }


        }

        private void DropShild()
        {
            gatShield = false;
            resist = 0;
        }

        private void ShieldTimer()
        {
            if (gatShield)
            {
                shieldTime -= Time.deltaTime;
                if (shieldTime <= 0)
                {
                    DropShild();
                }
            }
        }


        //UI
        private void HpSliderUpdate()
        {
            float curHP = (_hpSlider.maxValue / maxHeatPoints) * curentHeatPoints;
            _hpSlider.value = curHP;
        }



        //checkpoints and game events

        private void GameOver()
        {
            gameOverScreen.SetActive(true);
            moves.moveAble = false;
            anim.SetBool("isDead", true);

        }

        public void NewCheckPoint(Vector3 newCheckpoint, bool levelIsDone)
        {
            checkPoint = newCheckpoint;
            Debug.Log("New checkpoint");
            if (levelIsDone == true)
            {

            }
        }

        public void LevelDone()
        {
            levelDoneScreen.SetActive(true);
        }

        private void StartAdvice()
        {
            MainMenu.singletonMenu.CallAdvice(0);

        }


    }
}
