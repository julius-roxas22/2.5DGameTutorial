using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class PoolObject : MonoBehaviour
    {
        public PoolObjectType poolObjectType;
        public float ScheduledTime;
        private Coroutine OffRoutine;

        private void OnEnable()
        {
            if (null != OffRoutine)
            {
                StopCoroutine(OffRoutine);
            }

            if (ScheduledTime > 0)
            {
                OffRoutine = StartCoroutine(ScheduledOff());
            }
        }

        public void TurnOff()
        {
            PoolManager.Instance.AddObject(this);
        }

        IEnumerator ScheduledOff()
        {
            yield return new WaitForSeconds(ScheduledTime);
            if (!PoolManager.Instance.PoolDictionary[poolObjectType].Contains(gameObject))
            {
                TurnOff();
            }
        }
    }
}