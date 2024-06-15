using UnityEngine;
using System.Collections.Generic;

namespace IndieGameDeveloper
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
    }


    public class CharacterControl : MonoBehaviour
    {
        private Rigidbody rBody;
        public Material material;
        public Animator animator;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public GameObject SpherePrefab;
        public List<GameObject> FrontSphereList = new List<GameObject>();
        public List<GameObject> BottomSphereList = new List<GameObject>();

        private void Awake()
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

