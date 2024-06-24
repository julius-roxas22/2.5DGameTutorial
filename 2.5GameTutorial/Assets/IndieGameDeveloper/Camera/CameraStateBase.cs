using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class CameraStateBase : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CameraTrigger[] arr = System.Enum.GetValues(typeof(CameraTrigger)) as CameraTrigger[];
            foreach (CameraTrigger t in arr)
            {
                CameraManager.Instance.GetCameraController.GetAnimator.ResetTrigger(t.ToString());
            }
        }
    }

}
