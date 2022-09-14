using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniorProject_01
{
    public class PoolMaker : MonoBehaviour
    {
        public static PoolMaker SharedInstance;
        public List<GameObject> pooledObjects;

        public GameObject objectPool;
        public int amountToPool;

        private void Awake()
        {
            if (SharedInstance == null)
            {
                SharedInstance = this;
            }

            else
                Debug.Log("Shared instance error on Awake");

        }

        private void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for(int i=0; i<amountToPool; i++)
            {
                tmp = Instantiate(objectPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }

        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }




    }
}