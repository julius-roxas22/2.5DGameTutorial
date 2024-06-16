using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;
        private void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        void Update()
        {
            characterControl.MoveRight = VirtualInputManager.Instance.MoveRight ? true : false;
            characterControl.MoveLeft = VirtualInputManager.Instance.MoveLeft ? true : false;
            characterControl.Jump = VirtualInputManager.Instance.Jump ? true : false;
            characterControl.Attack = VirtualInputManager.Instance.Attack ? true : false;
        }
    }

}
