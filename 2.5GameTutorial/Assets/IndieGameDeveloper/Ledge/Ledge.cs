using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class Ledge : MonoBehaviour
    {
        public Vector3 Offset;
        public Vector3 EndPosition;

        public static bool IsLedge(GameObject obj)
        {
            if (null != obj.GetComponent<Ledge>())
            {
                return true;
            }
            return false;
        }
    }
}