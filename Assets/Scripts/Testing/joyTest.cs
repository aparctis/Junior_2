using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class joyTest : MonoBehaviour
    {
        [SerializeField] private VariableJoystick joystick;

        [SerializeField] private Player_moves moves;

        [SerializeField] private Animator anim;

        private void FixedUpdate()
        {
            if (joystick.Direction.x != 0)
            {

                //

                if (anim.GetBool("isRun") != true) anim.SetBool("isRun", true);

                if (joystick.Direction.x > 0)
                {
                    moves.WalkRight(joystick.Direction.x);
                    anim.speed = (joystick.Direction.x);
                }
                if (joystick.Direction.x < 0)
                {
                    moves.WalkLeft(-joystick.Direction.x);
                    anim.speed = (-joystick.Direction.x);


                }


            }

            else
            {
                anim.SetBool("isRun", false);
                anim.speed = 1;

            }
        }
    }
}
