using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private bool levelDone = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                other.transform.GetComponent<PlayerController>().NewCheckPoint(transform.position, levelDone);
                Destroy(gameObject);
            }
        }
    }
}
