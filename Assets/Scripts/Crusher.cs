using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    [RequireComponent(typeof(Rigidbody))]
    public class Crusher : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("CrushAble"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
