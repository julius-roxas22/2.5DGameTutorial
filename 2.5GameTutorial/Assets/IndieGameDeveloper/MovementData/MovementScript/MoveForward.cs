using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/MoveForward")]
    public class MoveForward : ObjectBase
    {
        public AnimationCurve SpeedGraph;
        public float movementSpeed;
        public float BlockDistance;
        public bool IsConstant;

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

            if (IsConstant)
            {
                ConstantMove(characterControl, stateInfo);
            }
            else
            {
                ControlledMove(characterControl, stateInfo, animator);
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private void ConstantMove(CharacterControl characterControl, AnimatorStateInfo stateInfo)
        {
            if (!CheckFront(characterControl))
            {
                characterControl.Move(movementSpeed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
            }
        }

        private void ControlledMove(CharacterControl characterControl, AnimatorStateInfo stateInfo, Animator animator)
        {
            if (characterControl.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (characterControl.MoveRight && characterControl.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!characterControl.MoveRight && !characterControl.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (characterControl.MoveRight)
            {
                if (!CheckFront(characterControl))
                {
                    characterControl.Move(movementSpeed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
                }
                characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (characterControl.MoveLeft)
            {
                if (!CheckFront(characterControl))
                {
                    characterControl.Move(movementSpeed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
                }
                characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        bool CheckFront(CharacterControl characterControl)
        {
            foreach (GameObject obj in characterControl.FrontSphereList)
            {
                Debug.DrawRay(obj.transform.position, obj.transform.forward * BlockDistance, Color.red);
                RaycastHit hit;
                if (Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, BlockDistance))
                {
                    if (!characterControl.RagdollParts.Contains(hit.collider))
                    {
                        if (!IsBodyPart(hit.collider))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        bool IsBodyPart(Collider col)
        {
            CharacterControl characterControl = col.transform.root.GetComponent<CharacterControl>();

            if (null == characterControl)
            {
                return false;
            }

            if (characterControl.gameObject == col.gameObject)
            {
                return false;
            }

            if (characterControl.RagdollParts.Contains(col))
            {
                return true;
            }

            return false;
        }
    }
}

