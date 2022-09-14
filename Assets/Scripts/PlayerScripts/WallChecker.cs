using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class WallChecker : MonoBehaviour
    {
        private bool m_wallJump = false;
        public bool WallJumpAble => m_wallJump;

        






        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag.Equals("WallCanJump"))
            {
                m_wallJump = true;
                
            }

            else
            {
                m_wallJump = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("WallCanJump"))
            {
                m_wallJump = false;

            }
        }


    }
}
