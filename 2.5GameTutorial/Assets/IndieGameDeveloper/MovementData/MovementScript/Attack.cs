using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    [CreateAssetMenu(fileName = "Movement Ability", menuName = "IndieGameDev/New Ability/Attack")]
    public class Attack : ObjectBase
    {
        //public bool debug;
        public float StartAttackTime;
        public float EndTimeAttack;
        public List<string> CollingNames = new List<string>();
        public bool LaunchIntoAir;
        public bool MustCollide;
        public bool IsFacingAttacker;
        public float AttackRange;
        public int Maxhits;
        private List<AttackInfo> FinishedAttacks = new List<AttackInfo>();

        public override void OnEnterAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);

            GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.ATTACKINFO);
            AttackInfo info = obj.GetComponent<AttackInfo>();
            obj.SetActive(true);
            info.ResetAttackInfo(this, characterControl);

            if (!AttackManager.Instance.CurrentAttacks.Contains(info))
            {
                AttackManager.Instance.CurrentAttacks.Add(info);
            }
        }

        public override void OnUpdateAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            RegisterAttack(characterControl, stateInfo);
            DeRegisteredAttack(stateInfo);
            CheckCombo(stateInfo, characterControl, animator);
        }

        public override void OnExitAnimation(CharacterControl characterControl, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            ClearAttack();
        }

        private void CheckCombo(AnimatorStateInfo stateInfo, CharacterControl characterControl, Animator animator)
        {
            if (stateInfo.normalizedTime >= StartAttackTime + ((EndTimeAttack - StartAttackTime) / 3f))
            {
                if (stateInfo.normalizedTime < EndTimeAttack + ((EndTimeAttack - StartAttackTime) / 2f))
                {
                    if (characterControl.Attack)
                    {
                        animator.SetBool(TransitionParameter.Attack.ToString(), true);
                    }
                }
            }
        }

        public void ClearAttack()
        {
            FinishedAttacks.Clear();

            foreach (AttackInfo info in AttackManager.Instance.CurrentAttacks)
            {
                if (null == info || this == info.AttackAbility)
                {
                    FinishedAttacks.Add(info);
                }
            }

            foreach (AttackInfo info in FinishedAttacks)
            {
                if (AttackManager.Instance.CurrentAttacks.Contains(info))
                {
                    AttackManager.Instance.CurrentAttacks.Remove(info);
                }
            }
        }

        public void RegisterAttack(CharacterControl characterControl, AnimatorStateInfo stateInfo)
        {
            if (StartAttackTime <= stateInfo.normalizedTime && EndTimeAttack > stateInfo.normalizedTime)
            {
                foreach (AttackInfo info in AttackManager.Instance.CurrentAttacks)
                {
                    if (null == info)
                    {
                        continue;
                    }

                    if (info.AttackAbility == this && !info.IsRegisteredAttack)
                    {
                        //if (debug)
                        //{
                        //    Debug.Log(name + " registered " + stateInfo.normalizedTime);
                        //}

                        info.RegisteredAttack(this);
                    }
                }
            }
        }

        public void DeRegisteredAttack(AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= EndTimeAttack)
            {
                foreach (AttackInfo info in AttackManager.Instance.CurrentAttacks)
                {
                    if (null == info)
                    {
                        continue;
                    }

                    if (info.AttackAbility == this && !info.IsFinishedAttack)
                    {
                        info.IsFinishedAttack = true;
                        info.GetComponent<PoolObject>().TurnOff();

                        //if (debug)
                        //{
                        //    Debug.Log(name + " registered " + stateInfo.normalizedTime);
                        //}
                    }
                }
            }
        }
    }
}

