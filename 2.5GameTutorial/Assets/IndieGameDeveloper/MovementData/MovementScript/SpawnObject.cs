using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/SpawnObject")]
    public class SpawnObject : ObjectBase
    {
        [Range(0f, 1f)]
        public float SpawnTiming;

        private bool IsSpawned;

        public PoolObjectType poolType;

        public string ParentObjName;
        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (SpawnTiming == 0)
            {
                SpawnObj(characterControl);
                IsSpawned = true;
            }
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!IsSpawned && stateInfo.normalizedTime >= SpawnTiming)
            {
                SpawnObj(characterControl);
                IsSpawned = true;
            }
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            IsSpawned = false;
        }

        private void SpawnObj(CharacterControl characterControl)
        {
            GameObject obj = PoolManager.Instance.GetObject(poolType);
            obj.SetActive(true);
            if (!string.IsNullOrEmpty(ParentObjName))
            {
                GameObject parentObj = characterControl.GetChildObject(ParentObjName);
                obj.transform.parent = parentObj.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
            }
        }
    }

}