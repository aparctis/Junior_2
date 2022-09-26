using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JuniorProject_01
{
    public class BridgeUp : ActionCaller
    {
        [SerializeField] private Transform upPosition;
        private bool startMove = false;
        private float speed = 2f;

        private void Start()
        {
            InitButton(StartMove);
        }

        void FixedUpdate()
        {
            if (startMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, upPosition.position, speed * Time.fixedDeltaTime);
            }
        }

        public void StartMove()
        {
            startMove = true;
        }

    }
}
