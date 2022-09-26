using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class RatAnimationEvents : MonoBehaviour
    {
        [SerializeField] private RatMover mover;

        public void AtackCheck()
        {
            mover.DamagePlayer();
        }




    }
}
