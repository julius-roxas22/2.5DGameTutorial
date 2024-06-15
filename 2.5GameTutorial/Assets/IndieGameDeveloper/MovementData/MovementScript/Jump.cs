using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/Jump")]
    public class Jump : ObjectBase
    {
        public float jumpForce;
        public AnimationCurve GravityMultiplier;
        public AnimationCurve PullMultiplier;

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl.GetRigidbody.AddForce(Vector3.up * jumpForce);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl.GravityMultiplier = GravityMultiplier.Evaluate(stateInfo.normalizedTime);
            characterControl.PullMultiplier = PullMultiplier.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

    }

}