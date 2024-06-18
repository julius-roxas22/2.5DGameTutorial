using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGameDeveloper
{
    public class AttackInfo : MonoBehaviour
    {
        public CharacterControl Attacker = null;
        public Attack AttackAbility;
        public List<string> CollingNames = new List<string>();
        public bool MustCollide;
        public bool IsFacingAttacker;
        public float AttackRange;
        public int Maxhits;
        public int CurrentHits;
        public bool IsRegisteredAttack;
        public bool IsFinishedAttack;

        public void ResetAttackInfo(Attack attack, CharacterControl attacker)
        {
            IsRegisteredAttack = false;
            IsFinishedAttack = false;
            AttackAbility = attack;
            Attacker = attacker;
        }

        public void RegisteredAttack(Attack attack)
        {
            IsRegisteredAttack = true;

            AttackAbility = attack;
            CollingNames = attack.CollingNames;
            MustCollide = attack.MustCollide;
            IsFacingAttacker = attack.IsFacingAttacker;
            AttackRange = attack.AttackRange;
            Maxhits = attack.Maxhits;
            CurrentHits = 0;
        }

        private void OnDisable()
        {
            IsFinishedAttack = true;
        }
    }
}

