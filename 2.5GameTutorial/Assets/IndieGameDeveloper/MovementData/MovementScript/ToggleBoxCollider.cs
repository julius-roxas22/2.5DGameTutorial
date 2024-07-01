using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/ToggleBoxCollider")]
    public class ToggleBoxCollider : ObjectBase
    {
        public bool OnEnabled;
        public bool OnStart;
        public bool OnEnd;
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnStart)
            {
                ToggleBoxCol(characterControl);
            }
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnEnd)
            {
                ToggleBoxCol(characterControl);
            }
        }

        private void ToggleBoxCol(CharacterControl characterControl)
        {
            characterControl.GetComponent<BoxCollider>().enabled = OnEnabled;
        }
    }

}