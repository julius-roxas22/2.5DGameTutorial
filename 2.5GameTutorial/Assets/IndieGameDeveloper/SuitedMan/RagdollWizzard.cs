using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class RagdollWizzard : MonoBehaviour
    {

        public List<Collider> RagdollParts = new List<Collider>();
        private CharacterControl characterControl;

        private void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        public void TurnOnRagdoll()
        {
            GetComponent<BoxCollider>().enabled = false;
            characterControl.GetRigidbody.velocity = Vector3.zero;
            characterControl.GetRigidbody.useGravity = false;
            characterControl.SkinnedMesh.enabled = false;
            characterControl.SkinnedMesh.avatar = null;

            foreach (Collider col in RagdollParts)
            {
                col.isTrigger = false;
                col.attachedRigidbody.velocity = Vector3.zero;
            }
        }

        public void SetRagdollParts()
        {
            RagdollParts.Clear();
            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider col in colliders)
            {
                if (col.gameObject != gameObject)
                {
                    col.isTrigger = true;
                    RagdollParts.Add(col);
                    if (null == col.GetComponent<TriggerDetector>())
                    {
                        col.gameObject.AddComponent<TriggerDetector>();
                    }
                }
            }
        }
    }
}