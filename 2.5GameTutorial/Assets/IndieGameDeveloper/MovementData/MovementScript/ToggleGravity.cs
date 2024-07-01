using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/ToggleGravity")]
    public class ToggleGravity : ObjectBase
    {
        public bool OnEnabled;
        public bool OnStart;
        public bool OnEnd;
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnStart)
            {
                ToggleGrav(characterControl);
            }
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnEnd)
            {
                ToggleGrav(characterControl);
            }
        }

        private void ToggleGrav(CharacterControl characterControl)
        {
            characterControl.GetRigidbody.velocity = Vector3.zero;
            characterControl.GetRigidbody.useGravity = OnEnabled;
        }
    }

}