using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class StateBase : StateMachineBehaviour
    {
        private CharacterControl playerController;

        public List<ObjectBase> allData = new List<ObjectBase>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CharacterControl characterControl = GetPlayerController(animator);
            foreach (ObjectBase data in allData)
            {
                data.OnEnterAnimation(characterControl, animator);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CharacterControl characterControl = GetPlayerController(animator);
            foreach (ObjectBase data in allData)
            {
                data.OnUpdateAnimation(characterControl, animator);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CharacterControl characterControl = GetPlayerController(animator);
            foreach (ObjectBase data in allData)
            {
                data.OnExitAnimation(characterControl, animator);
            }
        }

        public CharacterControl GetPlayerController(Animator animator)
        {
            if (null == playerController)
            {
                playerController = animator.GetComponentInParent<CharacterControl>();
            }
            return playerController;
        }
    }

}