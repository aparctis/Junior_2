using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class FB_pooler : MonoBehaviour
    {
        [SerializeField]private Player_moves moves;
        [SerializeField] private Transform startPoint;
        
        
        Vector3 atackDirection;

        private GameObject proj;

        public void CheckAtackDirection()
        {
            atackDirection = new Vector3(moves.lookDirectionX, 0, 0);
        }

        public void AtackDown()
        {
            CheckAtackDirection();
            moves.moveAble = false;
            proj = PoolMaker.SharedInstance.GetPooledObject();
            if (proj != null)
            {
                proj.transform.position = startPoint.position;
                proj.SetActive(true);
                proj.GetComponent<PooledFireBall>().SetDirection(atackDirection);

            }
            Debug.Log(proj.transform.position);

        }

        public void AtackUp()
        {
            moves.moveAble = true;

            if (proj != null && proj.GetComponent<PooledFireBall>() != null)
            {
                proj.GetComponent<PooledFireBall>().Fire(atackDirection);

            }
        }


    }
}
