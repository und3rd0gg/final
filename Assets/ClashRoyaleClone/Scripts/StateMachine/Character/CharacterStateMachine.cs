﻿using System;
using System.Collections.Generic;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterStateMachine : StateMachine
{
    protected IAttackable MainTarget;

    protected override void Start()
    {
        base.Start();
        SetBehaviourByDefault<MoveState>();
    }

    protected override void InitializeBehaviorMap()
    {
        CharacterBehaviorsMap = new Dictionary<Type, StateMachineBehaviour>
        {
            {
                typeof(MoveState),
                new MoveState(GetComponent<Mover>(), MainTarget.Position, GetComponentInChildren<IDetector>())
            },
            {typeof(AttackState), new AttackState(MainTarget, GetComponent<Animator>())}
        };
    }
}