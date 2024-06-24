using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public enum CameraTrigger
    {
        Default,
        Shake
    }

    public class CameraController : MonoBehaviour
    {
        private Animator animator;

        public Animator GetAnimator
        {
            get
            {
                if (null == animator)
                {
                    animator = GetComponent<Animator>();
                }
                return animator;
            }
        }

        public void TriggerCamera(CameraTrigger trigger)
        {
            GetAnimator.SetTrigger(trigger.ToString());
        }
    }
}

