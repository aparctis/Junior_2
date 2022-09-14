using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Distructuble : MonoBehaviour
    {
        [SerializeField] private float heatPoints;


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
