using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JuniorProject_01
{
    public class Distructuble : MonoBehaviour
    {
        [SerializeField] internal float heatPoints;
        internal float maxHP;

        //Has HP slider or not
        [SerializeField] internal Slider hpSlider;

        private void Start()
        {


        }

        public virtual void GetDamage(float damage)
        {
            heatPoints -= damage;
            if (heatPoints <= 0) DestroyIt();


        }

        internal virtual void DestroyIt()
        {
            Destroy(gameObject);
        }




    }
}
