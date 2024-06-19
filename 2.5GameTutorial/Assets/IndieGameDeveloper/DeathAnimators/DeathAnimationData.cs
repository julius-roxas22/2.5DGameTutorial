using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Death Animation Data" , menuName = "IndieGameDev/DeathData/DeathAnimationData")]
    public class DeathAnimationData : ScriptableObject
    {
        public List<GeneralBodyParts> BodyParts = new List<GeneralBodyParts>();
        public RuntimeAnimatorController AnimatorController;
        public bool IsFacingAttacker;
    }
}