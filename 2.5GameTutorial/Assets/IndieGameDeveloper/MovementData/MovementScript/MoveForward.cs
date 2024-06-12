using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/MoveForward")]
    public class MoveForward : ObjectBase
    {
        public float movementSpeed;

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

            if (!VirtualInputManager.Instance.MoveRight && !VirtualInputManager.Instance.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (VirtualInputManager.Instance.MoveRight)
            {
                characterControl.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                characterControl.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator)
        {

        }
    }
}

