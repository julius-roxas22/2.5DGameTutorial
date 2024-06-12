using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/Idle")]
    public class Idle : ObjectBase
    {
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator)
        {
            if (VirtualInputManager.Instance.MoveRight && VirtualInputManager.Instance.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (VirtualInputManager.Instance.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator)
        {

        }
    }

}