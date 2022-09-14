using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private WeaponeType m_type;
        public WeaponeType type => m_type;

        

    }
}
