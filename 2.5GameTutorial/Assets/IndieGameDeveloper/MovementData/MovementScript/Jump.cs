using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/Jump")]
    public class Jump : ObjectBase
    {
        [Range(0, 1f)]
        public float JumpTiming;
        private bool isJumped;

        public float jumpForce;
        public AnimationCurve PullMultiplier;

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (JumpTiming == 0f)
            {
                characterControl.GetRigidbody.AddForce(Vector3.up * jumpForce);
                isJumped = true;
            }
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl.PullMultiplier = PullMultiplier.Evaluate(stateInfo.normalizedTime);
            if (!isJumped && stateInfo.normalizedTime >= JumpTiming)
            {
                characterControl.GetRigidbody.AddForce(Vector3.up * jumpForce);
                isJumped = true;
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl.PullMultiplier = 0f;
            isJumped = false;
        }

    }

}