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
                if (anim.GetBool("isRun") != true) anim.SetBool("isRun", true);

                if (joystick.Direction.x > 0)
                {
                    moves.WalkRight();
                }
                if (joystick.Direction.x < 0)
                {
                    moves.WalkLeft();

                }


            }

            else
            {
                anim.SetBool("isRun", false);
            }
        }
    }
}
