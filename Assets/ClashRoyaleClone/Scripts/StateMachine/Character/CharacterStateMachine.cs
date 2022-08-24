using System;
using System.Collections.Generic;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Attacker))]
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
            { typeof(AttackState), new AttackState(Settings, GetComponent<Attacker>()) },
        };
    }
}

public class CharacterStateMachineSettings
{
    public IDamagable CurrentTarget;

    public PlaySide PlaySide { get; private set; }

    public IDamagable MainTarget { get; private set; }

    public CharacterStateMachineSettings(PlaySide playSide, IDamagable mainTarget)
    {
        PlaySide = playSide;
        MainTarget = mainTarget;
        CurrentTarget = MainTarget;
    }
}