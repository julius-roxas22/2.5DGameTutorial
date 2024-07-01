using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public enum TransitionIndexType
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ATTACK,
        JUMP,
        GRABBING_LEDGE
    }

    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/TransitionIndexer")]
    public class TransitionIndexer : ObjectBase
    {
        public int index;
        public List<TransitionIndexType> TransitionTypes = new List<TransitionIndexType>();

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (MakeTransition(characterControl))
            {
                animator.SetInteger(TransitionParameter.TransitionIndex.ToString(), index);
            }
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (MakeTransition(characterControl))
            {
                animator.SetInteger(TransitionParameter.TransitionIndex.ToString(), index);
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetInteger(TransitionParameter.TransitionIndex.ToString(), 0);
        }

        private bool MakeTransition(CharacterControl characterControl)
        {
            foreach (TransitionIndexType transitions in TransitionTypes)
            {
                switch (transitions)
                {
                    case TransitionIndexType.UP:
                        {
                            if (!characterControl.MoveUp)
                            {
                                return false;
                            }
                            break;
                        }
                    case TransitionIndexType.DOWN:
                        {
                            if (!characterControl.MoveDown)
                            {
                                return false;
                            }
                            break;
                        }
                    case TransitionIndexType.LEFT:
                        {
                            if (!characterControl.MoveLeft)
                            {
                                return false;
                            }
                            break;
                        }
                    case TransitionIndexType.RIGHT:
                        {
                            if (!characterControl.MoveRight)
                            {
                                return false;
                            }
                            break;
                        }
                    case TransitionIndexType.ATTACK:
                        {
                            break;
                        }
                    case TransitionIndexType.JUMP:
                        {
                            break;
                        }
                    case TransitionIndexType.GRABBING_LEDGE:
                        {
                            if (!characterControl.ledgeChecker.IsGrabbing)
                            {
                                return false;
                            }
                            break;
                        }
                }
            }

            return true;
        }
    }

}