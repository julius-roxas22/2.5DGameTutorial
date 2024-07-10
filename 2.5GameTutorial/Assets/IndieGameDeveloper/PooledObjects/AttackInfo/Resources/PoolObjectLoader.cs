using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public enum PoolObjectType
    {
        ATTACKINFO,
        THORHAMMER,
        LARGEAXE,
    }

    public class PoolObjectLoader : MonoBehaviour
    {
        public static PoolObject InstantiatePrefab(PoolObjectType objectType)
        {
            GameObject obj = null;
            switch (objectType)
            {
                case PoolObjectType.ATTACKINFO:
                    {
                        obj = Instantiate(Resources.Load("AttackInfo", typeof(GameObject))) as GameObject;
                        break;
                    }
                case PoolObjectType.THORHAMMER:
                    {
                        obj = Instantiate(Resources.Load("ThorHammer", typeof(GameObject))) as GameObject;
                        break;
                    }
                case PoolObjectType.LARGEAXE:
                    {
                        obj = Instantiate(Resources.Load("Axe", typeof(GameObject))) as GameObject;
                        break;
                    }
            }
            return obj.GetComponent<PoolObject>();
        }
    }
}


