using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/GravityPull")]
    public class GravityPull : ObjectBase
    {
        public AnimationCurve GravityMultiplier;
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl.GravityMultiplier = GravityMultiplier.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl.GravityMultiplier = 0;
        }
    }

}