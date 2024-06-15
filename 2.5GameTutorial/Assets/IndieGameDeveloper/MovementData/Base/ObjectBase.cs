using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public abstract class ObjectBase : ScriptableObject
    {
        public abstract void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo);
    }
}
