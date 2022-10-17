using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class EnemyCrusher : MonoBehaviour
    {
        [SerializeField] private float damageToEnemys = 100f;

        private List<Distructuble> enemys = new List<Distructuble>();

        public void DamageEnemys()
        {
            if (enemys.Count > 0)
            {
                foreach (Distructuble enemy in enemys)
                {
                    enemy.GetDamage(damageToEnemys);
                }
            }

            else
            {
                Debug.Log("no enemys under mushroom");
            }
        }



        private void OnTriggerEnter(Collider other)
        {


            if (other.gameObject.tag.Equals("Enemy"))
            {

                if (other.gameObject.GetComponent<Distructuble>() != null)
                {
                    Distructuble newEnemy = other.gameObject.GetComponent<Distructuble>();
                    enemys.Add(newEnemy);

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                if (other.gameObject.GetComponent<Distructuble>() != null)
                {
                    Distructuble newEnemy = other.gameObject.GetComponent<Distructuble>();
                    enemys.Remove(newEnemy);

                }
            }
        }

    }
}
