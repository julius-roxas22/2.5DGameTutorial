using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public enum TransitionParameter
    {
        Move
    }


    public class CharacterControl : MonoBehaviour
    {
        public Material material;
        public Animator animator;

        public void ChangeMaterial()
        {
            Renderer[] materialBodyParts = GetComponentsInChildren<Renderer>();

            if (null == material)
            {
                Debug.LogError("No Material Specified");
            }

            foreach (Renderer arr in materialBodyParts)
            {
                if (arr.gameObject != gameObject)
                {
                    arr.material = material;
                }
            }
        }
    }
}

