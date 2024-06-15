using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class KeyboardInput : MonoBehaviour
    {
        private void Update()
        {
            VirtualInputManager.Instance.MoveRight = Input.GetKey(KeyCode.D) ? true : false;
            VirtualInputManager.Instance.MoveLeft = Input.GetKey(KeyCode.A) ? true : false;
            VirtualInputManager.Instance.Jump = Input.GetKey(KeyCode.Space) ? true : false;
        }
    }
}