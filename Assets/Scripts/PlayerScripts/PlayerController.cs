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
        [SerializeField] private Transform castPoint;

        //weapoons
        private Vector3 atackDirection;
        [SerializeField] private WeaponeType weapone;
        private GameObject proj;

        [SerializeField] GameObject fireball;

        //stats
        private float curentHeatPoints;
        [SerializeField] private float maxHeatPoints = 100;
        [SerializeField ]private int lives = 2;

        //UI
        [SerializeField]private Slider _hpSlider;

        //death and respawn
        private Vector3 checkPoint;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject levelDoneScreen;

        //runes
        [SerializeField] private Button but_fire;
        [SerializeField] private Button but_water;
        [SerializeField] private Button but_wind;
        [SerializeField] private Button but_earth;

        [SerializeField]private bool fireAble;
        [SerializeField]private bool waterAble;
        [SerializeField] private bool windAble;
        [SerializeField] private bool earthAble;

        private int fire_rune_count;
        private int water_rune_count;
        private int earth_rune_count;
        private int wind_rune_count;


        private void Start()
        {
            atackDirection = Vector3.right;

            checkPoint = transform.position;
            curentHeatPoints = maxHeatPoints;

            HpSliderUpdate();

        }

        private void Update()
        {
            
        }


        //Weapones & atack

        public void CheckAtackDirection()
        {
            atackDirection = new Vector3(moves.lookDirectionX, 0, 0);
        }
        public void AtackDown()
        {
            CheckAtackDirection();
            moves.moveAble = false;
            if (fireAble)
            {
                proj = Instantiate(fireball, castPoint.position, Quaternion.identity) as GameObject;
                proj.GetComponent<Fireball>().SetDirection(atackDirection);
            }
        }

        public void AtackUp()
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

        private void ButtonCheck()
        {
            but_fire.interactable = fireAble;
            but_water.interactable = waterAble;
            but_wind.interactable = windAble;
            but_earth.interactable = earthAble;

        }

        public void AddCrystal(WeaponeType type)
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


        //hp and damage
        public void GetDamage(float damage)
        {
            Debug.Log("GetDamage: " + damage);

            curentHeatPoints -= damage;
            if (curentHeatPoints <= 0) Death();
            HpSliderUpdate();
        }

        public void Heal(float heal)
        {
            curentHeatPoints += heal;
            if (curentHeatPoints > maxHeatPoints) curentHeatPoints = maxHeatPoints;
            HpSliderUpdate();

        }

        private void Death()
        {
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




    }
}
