using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterStateMachine : StateMachine
{
    private IAttackable _currentTarget;

    protected virtual void Start()
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