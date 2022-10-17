using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JuniorProject_01
{
    public class BloodScreen : MonoBehaviour
    {
        public static BloodScreen singleton;

        [SerializeField] private Image m_screen;

        //time
        [SerializeField] private float bleedTime = 1.0f;
        private float timer;
        private bool isBleeding = false;

        //alpha
        private float maxAlpha = 255.0f;
        private float minAlpa = 40.0f;
        private float defoultAlpha = 0f;
        private float curentAlpha;
        private float changeAlphaSpeed;

        void Start()
        {
            if (singleton == null) singleton = this;

        }

        private void FixedUpdate()
        {
            if (isBleeding) BloodTimer();


            Debug.Log(m_screen.color);

        }

        public void Bleed(float damage)
        {


            float newAlpha = damage * 2.55f;
            if (newAlpha < minAlpa) newAlpha = minAlpa;
            else if (newAlpha > maxAlpha) newAlpha = maxAlpha;

            curentAlpha = (newAlpha/100);
            changeAlphaSpeed = ((newAlpha) / bleedTime)/100;
            timer = bleedTime;
            isBleeding = true;

        }

        private void AlphaCheck()
        {
            m_screen.color = new Color(1.0f, 1.0f, 1.0f, curentAlpha);

            //m_screen.material.color = new Color(255, 255, 255, curentAlpha);
        }


        private void BloodTimer()
        {
            Debug.Log("Is bleeding");

            curentAlpha -= (changeAlphaSpeed * Time.fixedDeltaTime);

            if (curentAlpha <= 0)
            {
                isBleeding = false;
                curentAlpha = defoultAlpha;
            }

            AlphaCheck();
        }

    }
}
