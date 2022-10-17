using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class CatAnimations : MonoBehaviour
    {
        private AudioSource source;
        //sounds for animation
        [SerializeField] private AudioClip step_lef;
        [SerializeField] private AudioClip step_right;
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip land;
        [SerializeField] private AudioClip getDamage;
        [SerializeField] private AudioClip deathStart;
        [SerializeField] private AudioClip deathEnd;

        //magic cast
        [SerializeField] private Player_Atacks magic;


        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        //sound functions for animation
        public void StepRightSound()
        {
            source.clip = step_lef;
            source.Play();
        }

        public void StepLeftSound()
        {
            source.clip = step_right;
            source.Play();
        }

        public void JumpSound()
        {
            source.clip = jump;
            source.Play();
        }

        public void LandSound()
        {
            source.clip = land;
            source.Play();
        }

        public void GetDamageSound()
        {
            source.clip = getDamage;
            source.Play();
        }

        public void DeathStart()
        {
            source.clip = deathStart;
            source.Play();
        }

        public void DeathEnd()
        {
            source.clip = deathEnd;
            source.Play();
        }

        public void FireBall()
        {
            magic.Fireball_forInvoke();
        }

    }
}
