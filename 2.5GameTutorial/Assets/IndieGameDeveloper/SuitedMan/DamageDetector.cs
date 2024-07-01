using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class DamageDetector : MonoBehaviour
    {
        private CharacterControl characterControl;
        private GeneralBodyParts BodyPart;

        private void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (AttackManager.Instance.CurrentAttacks.Count > 0)
            {
                CheckAttack();
            }
        }

        private void CheckAttack()
        {
            foreach (AttackInfo info in AttackManager.Instance.CurrentAttacks)
            {
                if (null == info)
                {
                    continue;
                }

                if (!info.IsRegisteredAttack)
                {
                    continue;
                }

                if (info.IsFinishedAttack)
                {
                    continue;
                }

                if (info.CurrentHits >= info.Maxhits)
                {
                    continue;
                }

                if (info.Attacker == characterControl)
                {
                    continue;
                }

                if (info.MustCollide)
                {
                    if (IsCollided(info))
                    {
                        TakeDamage(info);
                    }
                }
                else
                {
                    float distance = Vector3.SqrMagnitude(characterControl.transform.position - info.Attacker.transform.position);
                    if (distance <= info.AttackRange)
                    {
                        TakeDamage(info);
                    }
                }
            }
        }

        private bool IsCollided(AttackInfo info)
        {
            foreach (TriggerDetector triggers in characterControl.GetAllTriggers())
            {
                foreach (Collider col in triggers.CollidingParts)
                {
                    foreach (string colName in info.CollingNames)
                    {
                        if (col.name.Equals(colName))
                        {
                            BodyPart = triggers.BodyPart;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void TakeDamage(AttackInfo info)
        {
            if (info.MustCollide)
            {
                CameraManager.Instance.ShakeCamera(.35f);
            }
            characterControl.SkinnedMesh.runtimeAnimatorController = DeathAnimationManager.Instance.GetDeathAnimator(BodyPart, info);
            info.CurrentHits++;
            characterControl.GetComponent<BoxCollider>().enabled = false;
            characterControl.GetRigidbody.useGravity = false;
        }
    }
}