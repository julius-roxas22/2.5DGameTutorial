using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/CheckGround")]
    public class CheckGround : ObjectBase
    {
        [Range(0.01f, 1f)]
        public float CheckTiming;

        public float groundDistance;

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= CheckTiming)
            {
                if (IsGrounded(characterControl))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool IsGrounded(CharacterControl characterControl)
        {

            if (characterControl.GetRigidbody.velocity.y > -0.001f && characterControl.GetRigidbody.velocity.y <= 0f)
            {
                return true;
            }

            if (characterControl.GetRigidbody.velocity.y < 0f)
            {
                foreach (GameObject obj in characterControl.BottomSphereList)
                {
                    Debug.DrawRay(obj.transform.position, -Vector3.up * groundDistance, Color.red);
                    RaycastHit hit;
                    if (Physics.Raycast(obj.transform.position, -Vector3.up, out hit, groundDistance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

}