using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/TeleportOnLedge")]
    public class TeleportOnLedge : ObjectBase
    {
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl getControl = CharacterManager.Instance.GetCharacterControl(animator);
            Vector3 endPosition = getControl.ledgeChecker.LedgeGrab.transform.position + getControl.ledgeChecker.LedgeGrab.EndPosition;
            getControl.transform.position = endPosition;
            getControl.SkinnedMesh.transform.position = endPosition;
            getControl.SkinnedMesh.transform.parent = getControl.transform;
        }
    }

}