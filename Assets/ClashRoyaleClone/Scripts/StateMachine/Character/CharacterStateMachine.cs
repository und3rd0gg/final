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
    // protected struct MyStruct
    // {
    //     public IAttackable MainTarget;
    //     public IAttackable CurrentTarget;
    // }
    
    protected IAttackable MainTarget;
    protected IAttackable CurrentTarget;

    protected override void Start()
    {
        base.Start();
        SetBehaviourByDefault<MoveState>();
    }

    protected override void InitializeBehaviorMap()
    {
        CurrentTarget = MainTarget;
        
        BehaviorMap = new Dictionary<Type, StateMachineBehaviour>
        {
            {
                typeof(MoveState),
                new MoveState(GetComponent<Mover>(), ref CurrentTarget, GetComponentInChildren<IDetector>())
            },
            {typeof(AttackState), new AttackState(CurrentTarget, GetComponent<Animator>())}
        };
    }

    private void LateUpdate()
    {
        Debug.Log(CurrentTarget);
    }
}