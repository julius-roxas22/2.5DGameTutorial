using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class DeathAnimationManager : Singleton<DeathAnimationManager>
    {
        private DeathAnimationLoader deathAnimationLoader;
        private List<RuntimeAnimatorController> Candidates = new List<RuntimeAnimatorController>();

        private void SetUpDeathAnimationLoader()
        {
            if (null == deathAnimationLoader)
            {
                GameObject obj = Instantiate(Resources.Load("DeathAnimationLoader", typeof(GameObject))) as GameObject;
                DeathAnimationLoader loader = obj.GetComponent<DeathAnimationLoader>();
                deathAnimationLoader = loader;
            }
        }

        public RuntimeAnimatorController GetDeathAnimator(GeneralBodyParts generalBodyParts, AttackInfo info)
        {
            SetUpDeathAnimationLoader();
            Candidates.Clear();

            foreach (DeathAnimationData data in deathAnimationLoader.deathAnimationDatas)
            {
                if (info.LaunchIntoAir)
                {
                    if (data.LaunchIntoAir)
                    {
                        Candidates.Add(data.DeathAnimatorController);
                    }
                }
                else
                {
                    foreach (GeneralBodyParts body in data.BodyParts)
                    {
                        if (body == generalBodyParts)
                        {
                            Candidates.Add(data.DeathAnimatorController);
                            break;
                        }
                    }
                }
            }
            return Candidates[Random.Range(0, Candidates.Count)];
        }
    }
}

