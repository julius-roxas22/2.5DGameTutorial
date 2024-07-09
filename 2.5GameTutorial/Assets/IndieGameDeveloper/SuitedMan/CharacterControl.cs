using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace IndieGameDeveloper
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
        Attack,
        TransitionIndex
    }

    public class CharacterControl : MonoBehaviour
    {
        public CharacterType Character;
        private Rigidbody rBody;
        public Material material;
        public Animator SkinnedMesh;
        public bool MoveUp;
        public bool MoveDown;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Attack;

        public GameObject SpherePrefab;
        public List<GameObject> FrontSphereList = new List<GameObject>();
        public List<GameObject> BottomSphereList = new List<GameObject>();
        public float GravityMultiplier;
        public float PullMultiplier;
        public List<TriggerDetector> TriggerDetectors = new List<TriggerDetector>();
        private RagdollWizzard ragdDollWizzard;
        public LedgeChecker ledgeChecker;

        public RagdollWizzard RAGDOLL_WIZZARD
        {
            get
            {
                if (null == ragdDollWizzard)
                {
                    ragdDollWizzard = GetComponent<RagdollWizzard>();
                }
                return ragdDollWizzard;
            }
        }

        private void Awake()
        {
            bool SwitchBack = false;

            if (!IsFacingForward()) //check the character is facing forward at the world position
            {
                SwitchBack = true;
            }

            ResetRotationToFaceForward(true);

            SetColliderSphere();

            if (SwitchBack)
            {
                ResetRotationToFaceForward(false);
            }

            ledgeChecker = GetComponentInChildren<LedgeChecker>();
            SetUpCharacter();
        }

        private void FixedUpdate()
        {
            if (GetRigidbody.velocity.y < 0f)
            {
                GetRigidbody.velocity -= (Vector3.up * GravityMultiplier);
            }

            if (GetRigidbody.velocity.y > 0f && !Jump)
            {
                GetRigidbody.velocity -= (Vector3.up * PullMultiplier);
            }
        }
        public void SetUpCharacter()
        {
            if (!CharacterManager.Instance.characterController.Contains(this))
            {
                CharacterManager.Instance.characterController.Add(this);
            }
        }

        public List<TriggerDetector> GetAllTriggers()
        {
            if (TriggerDetectors.Count == 0)
            {
                TriggerDetector[] Triggers = GetComponentsInChildren<TriggerDetector>();
                foreach (TriggerDetector trigger in Triggers)
                {
                    TriggerDetectors.Add(trigger);
                }
            }
            return TriggerDetectors;
        }

        public void Move(float movementSpeed, float SpeedGraph)
        {
            transform.Translate(Vector3.forward * movementSpeed * SpeedGraph * Time.deltaTime);
        }

        public bool IsFacingForward()
        {
            if (transform.forward.z > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetRotationToFaceForward(bool IsFacingForward)
        {
            if (IsFacingForward)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        private void SetColliderSphere()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();

            float top = boxCollider.bounds.center.y + boxCollider.bounds.extents.y;
            float bottom = boxCollider.bounds.center.y - boxCollider.bounds.extents.y;
            float front = boxCollider.bounds.center.z + boxCollider.bounds.extents.z;
            float back = boxCollider.bounds.center.z - boxCollider.bounds.extents.z;

            GameObject topFrontSpheres = CreateEdgeSphere(new Vector3(0f, top, front));
            GameObject bottomFrontSpheres = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom, back));

            FrontSphereList.Add(bottomFrontSpheres);
            FrontSphereList.Add(topFrontSpheres);
            BottomSphereList.Add(bottomFrontSpheres);
            BottomSphereList.Add(bottomBack);

            float verticalSection = (bottomFrontSpheres.transform.position - topFrontSpheres.transform.position).magnitude / 10f;
            SphereEdge(bottomFrontSpheres, Vector3.up, verticalSection, 9, FrontSphereList);

            float horizontalSection = (bottomBack.transform.position - bottomFrontSpheres.transform.position).magnitude / 5f;
            SphereEdge(bottomBack, Vector3.forward, horizontalSection, 4, BottomSphereList);
        }

        private void SphereEdge(GameObject objStartPosition, Vector3 directions, float section, int iteration, List<GameObject> sphereList)
        {
            for (int i = 0; i < iteration; i++)
            {
                Vector3 position = objStartPosition.transform.position + directions * section * (i + 1);
                GameObject obj = CreateEdgeSphere(position);
                sphereList.Add(obj);
            }
        }

        GameObject CreateEdgeSphere(Vector3 position)
        {
            return Instantiate(SpherePrefab, position, Quaternion.identity, transform);
        }

        public Rigidbody GetRigidbody
        {
            get
            {
                if (null == rBody)
                {
                    rBody = GetComponent<Rigidbody>();
                }
                return rBody;
            }
        }

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

