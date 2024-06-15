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

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
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
                    characterControl.transform.Translate(Vector3.forward * movementSpeed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
                characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (characterControl.MoveLeft)
            {
                if (!CheckFront(characterControl))
                {
                    characterControl.transform.Translate(Vector3.forward * movementSpeed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
                characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFront(CharacterControl characterControl)
        {
            RaycastHit hit;

            foreach (GameObject obj in characterControl.FrontSphereList)
            {
                Debug.DrawRay(obj.transform.position, obj.transform.forward * BlockDistance, Color.red);

                if (Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, BlockDistance))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

