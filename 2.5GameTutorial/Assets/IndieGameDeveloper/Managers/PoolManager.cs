using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class PoolManager : Singleton<PoolManager>
    {
        public Dictionary<PoolObjectType, List<GameObject>> PoolDictionary = new Dictionary<PoolObjectType, List<GameObject>>();

        private void SetUpDictionary()
        {
            PoolObjectType[] poolObjectTypes = System.Enum.GetValues(typeof(PoolObjectType)) as PoolObjectType[];

            foreach (PoolObjectType poolObject in poolObjectTypes)
            {
                if (!PoolDictionary.ContainsKey(poolObject))
                {
                    PoolDictionary.Add(poolObject, new List<GameObject>());
                }
            }
        }

        public GameObject GetObject(PoolObjectType objectType)
        {
            if (PoolDictionary.Count == 0)
            {
                SetUpDictionary();
            }

            List<GameObject> list = PoolDictionary[objectType];
            GameObject obj = null;

            if (list.Count > 0)
            {
                obj = list[0];
                list.RemoveAt(0);
            }
            else
            {
                obj = PoolObjectLoader.InstantiatePrefab(objectType).gameObject;
            }
            return obj;
        }

        public void AddObject(PoolObject poolObject)
        {
            List<GameObject> list = PoolDictionary[poolObject.poolObjectType];
            list.Add(poolObject.gameObject);
            poolObject.gameObject.SetActive(false);
        }
    }
}