using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JuniorProject_01
{
    public class ActionCaller : MonoBehaviour
    {
        [SerializeField] private FloreButon button;

        internal void InitButton (Action a)
        {
            if (button != null)
            {
                button.InitializeAction(a);
            }
        }

    }
}
