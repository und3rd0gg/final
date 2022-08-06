using System;
using System.Collections.Generic;
using ClashRoyaleClone.Scripts.Game.Abstractions;
using ClashRoyaleClone.Scripts.StateMachine.Character.States;
using UnityEngine;
using UnityEngine.AI;
using StateMachineBehaviour = ClashRoyaleClone.Scripts.StateMachine.Abstractions.StateMachineBehaviour;

namespace ClashRoyaleClone.Scripts.StateMachine.Character
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterStateMachine : Abstractions.StateMachine
    {
        private IAttackable _currentTarget;

        private void Start()
        {
            SetBehaviourByDefault<MoveState>();
        }

        protected override void InitializeBehaviorMap()
        {
            CharacterBehaviorsMap = new Dictionary<Type, StateMachineBehaviour>
            {
                {
                    typeof(MoveState),
                    new MoveState(GetComponent<NavMeshAgent>(), GetComponent<Animator>(),
                        GameObject.FindGameObjectWithTag("EnemyCastle").transform.position)
                },
                {typeof(AttackState), new AttackState(_currentTarget, GetComponent<Animator>())}
            };
        }
    }
}