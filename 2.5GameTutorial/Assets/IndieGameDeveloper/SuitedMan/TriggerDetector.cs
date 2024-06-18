using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public enum GeneralBodyParts
    {
        Upper,
        Lower,
        Arm,
        Leg
    }
    public class TriggerDetector : MonoBehaviour
    {
        private CharacterControl owner;
        public List<Collider> CollidingParts = new List<Collider>();
        public GeneralBodyParts BodyPart;

        private void Awake()
        {
            owner = GetComponentInParent<CharacterControl>();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (owner.RAGDOLL_WIZZARD.RagdollParts.Contains(col))
            {
                return;
            }

            CharacterControl attacker = col.transform.root.GetComponent<CharacterControl>();

            if (null == attacker)
            {
                return;
            }

            if (col.gameObject == attacker.gameObject)
            {
                return;
            }

            if (!CollidingParts.Contains(col))
            {
                CollidingParts.Add(col);
            }

        }

        private void OnTriggerExit(Collider col)
        {
            if (CollidingParts.Contains(col))
            {
                CollidingParts.Remove(col);
            }
        }
    }
}