using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public enum CharacterType
    {
        SuitedMan,
    }
    public class CharacterManager : Singleton<CharacterManager>
    {
        public List<CharacterType> CharacterTypes = new List<CharacterType>();
        private CharacterControl characterControl;

        public void CharacterSetup()
        {
            characterControl = FindObjectOfType<CharacterControl>();
            if (CharacterTypes.Count == 0)
            {
                CharacterTypes.Add(characterControl.Character);
            }
        }
    }
}

