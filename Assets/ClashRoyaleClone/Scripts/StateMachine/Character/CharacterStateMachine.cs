using System;
using System.Collections.Generic;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterStateMachine : StateMachine
{
    protected CharacterStateMachineSettings Settings;

    protected void Start()
    {
        SetBehaviourByDefault<MoveState>();
    }

    protected override void InitializeBehaviorMap()
    {
        BehaviorMap = new Dictionary<Type, StateMachineBehaviour>
        {
            {
                typeof(MoveState),
                new MoveState(Settings, GetComponent<Mover>(), GetComponentInChildren<IDetector>())
            },
            {typeof(AttackState), new AttackState(Settings, GetComponent<Attacker>())}
        };
    }
}

public class CharacterStateMachineSettings
{
    public IAttackable MainTarget;
    public IAttackable CurrentTarget;

    public CharacterStateMachineSettings(IAttackable mainTarget)
    {
        MainTarget = mainTarget;
        CurrentTarget = MainTarget;
    }
}