using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class HidenCave : MonoBehaviour
    {
        public bool startAction = false;

        //darkness
        [SerializeField] private GameObject darkness;
        [SerializeField] private float lightSpeed;
        private Vector3 darknessPos;
        [SerializeField]private Material darkMaterial;
        private Color dark = new Color(1,1,1,1);


        //wall
        [SerializeField] private GameObject wall;
        [SerializeField] private Transform wallDown;
        [SerializeField] private float wallSpeed = 2f;


        //signess
        private int sign1 = 0;
        private int sign2 = 0;
        private int sign3 = 0;


        void Start()
        {
            darknessPos = new Vector3(darkness.transform.position.x, darkness.transform.position.y, (darkness.transform.position.z+9f));

            //color
            darkMaterial.color = Color.black;
            dark = darkMaterial.color;

        }

        void FixedUpdate()
        {
            if (startAction)
            {
                LightOn();
                WallDown();
            }
        }

        private void LightOn()
        {
            //            darkness.transform.position = Vector3.MoveTowards(darkness.transform.position, darknessPos, lightSpeed * Time.fixedDeltaTime);

            dark.a -= 0.01f;
            darkMaterial.color = dark;
            Debug.Log(dark.a);
        }

        private void WallDown()
        {
            wall.transform.position = Vector3.MoveTowards(wall.transform.position, wallDown.position, wallSpeed * Time.fixedDeltaTime);

        }

        public void SignChange(int index, int oneIsTrue)
        {
            switch (index)
            {
                case 1:
                    sign1 = oneIsTrue;
                    AllPositionsCheck();
                    break;
                case 2:
                    sign2 = oneIsTrue;
                    AllPositionsCheck();
                    break;
                case 3:
                    sign3 = oneIsTrue;
                    AllPositionsCheck();
                    break;
            }
        }

        private void AllPositionsCheck()
        {
            if (sign1 + sign2 + sign3 == 3)
            {
                startAction = true;
            }
        }
    }
}
