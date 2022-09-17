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

        //UI
        [SerializeField]private Slider _hpSlider;

        //death and respawn
        private Vector3 checkPoint;
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private GameObject levelDoneScreen;

        //magic
        [SerializeField] private Player_Atacks atack;




        private void Start()
        {

            checkPoint = transform.position;
            curentHeatPoints = maxHeatPoints;

            HpSliderUpdate();

        }

        private void Update()
        {
            
        }


        //Weapones & atack



        public void AddCrystal(WeaponeType type)
        {
            atack.NewRune(type);
        }

        //fire atack




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
