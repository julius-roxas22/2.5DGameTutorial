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
        public List<CharacterControl> characterController = new List<CharacterControl>();

        public CharacterControl GetCharacterControl(CharacterType type)
        {
            foreach (CharacterControl character in characterController)
            {
                if (character.Character == type)
                    return character;
            }

            return null;
        }
        public CharacterControl GetCharacterControl(Animator animator)
        {
            foreach (CharacterControl character in characterController)
            {
                if (character.SkinnedMesh == animator)
                    return character;
            }

            return null;
        }
    }
}

