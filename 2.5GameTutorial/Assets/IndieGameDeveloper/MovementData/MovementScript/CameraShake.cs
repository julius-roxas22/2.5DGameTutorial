using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/CameraShake")]
    public class CameraShake : ObjectBase
    {
        [Range(0, 1f)]
        public float ShakeTiming;
        private bool isShaking;

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (ShakeTiming == 0)
            {
                CameraManager.Instance.ShakeCamera(.35f);
                isShaking = true;
            }
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!isShaking && stateInfo.normalizedTime >= ShakeTiming)
            {
                CameraManager.Instance.ShakeCamera(.35f);
                isShaking = true;
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            isShaking = false;
        }

    }

}