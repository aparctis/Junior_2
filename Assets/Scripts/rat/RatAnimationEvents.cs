using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class RatAnimationEvents : MonoBehaviour
    {
        [SerializeField] private RatMover mover;

        private AudioSource source;


        public List<AudioClip> allSounds = new List<AudioClip>();

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void AtackCheck()
        {
            mover.DamagePlayer();
        }

        public void PlaySound(int index)
        {
            source.clip = allSounds[index];
            source.Play();
        }


    }
}
