using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/CheckAttack")]
    public class CheckAttack : ObjectBase
    {
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (characterControl.Attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }
    }

}