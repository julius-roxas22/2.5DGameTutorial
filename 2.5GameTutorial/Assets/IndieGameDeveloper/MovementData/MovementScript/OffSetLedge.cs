using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/OffSetLedge")]
    public class OffSetLedge : ObjectBase
    {
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            Ledge GrabbedLedge = characterControl.ledgeChecker.LedgeOffset;
            GameObject animObject = characterControl.SkinnedMesh.gameObject;
            animObject.transform.parent = GrabbedLedge.transform;
            animator.transform.localPosition = GrabbedLedge.Offset;
            characterControl.GetRigidbody.velocity = Vector3.zero;
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}