using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Animator _animator;
    private CharacterStateMachineSettings _settings;

    public AttackState(CharacterStateMachineSettings settings, Animator animator) : base(new List<Transition>()
    {
        //
    })
    {
        _animator = animator;
        _settings = settings;
    }

    public override void Enter()
    {
        //throw new System.NotImplementedException();
    }

    public override void Tick()
    {
        Debug.Log(" текущая цель: " + _settings.CurrentTarget.ToString());
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }
}