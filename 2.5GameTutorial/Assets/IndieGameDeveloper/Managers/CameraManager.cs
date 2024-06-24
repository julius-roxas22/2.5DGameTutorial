using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class CameraManager : Singleton<CameraManager>
    {
        private Coroutine routine;
        private CameraController cameraController;
        public CameraController GetCameraController
        {
            get
            {
                if (null == cameraController)
                {
                    cameraController = FindObjectOfType<CameraController>();
                }
                return cameraController;
            }
        }

        private IEnumerator CamShake(float duration)
        {
            GetCameraController.TriggerCamera(CameraTrigger.Shake);
            yield return new WaitForSeconds(duration);
            GetCameraController.TriggerCamera(CameraTrigger.Default);
        }

        public void ShakeCamera(float duration)
        {
            if (null != routine)
            {
                StopCoroutine(routine);
            }
            routine = StartCoroutine(CamShake(duration));
        }
    }

}
