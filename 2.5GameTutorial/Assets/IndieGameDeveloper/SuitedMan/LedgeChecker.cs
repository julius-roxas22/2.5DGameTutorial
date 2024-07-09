using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class LedgeChecker : MonoBehaviour
    {
        public Ledge LedgeGrab;
        public bool IsGrabbing;
        private Ledge LedgeChecking;
        private void OnTriggerEnter(Collider col)
        {
            LedgeChecking = col.GetComponent<Ledge>();
            if (null != LedgeChecking)
            {
                IsGrabbing = true;
                LedgeGrab = LedgeChecking;
            }
        }

        private void OnTriggerExit(Collider col)
        {
            LedgeChecking = col.GetComponent<Ledge>();
            if (null != LedgeChecking)
            {
                IsGrabbing = false;
            }
        }
    }
}