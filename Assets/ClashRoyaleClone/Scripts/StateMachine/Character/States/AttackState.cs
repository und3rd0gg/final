using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Attacker _attacker;
    private CharacterStateMachineSettings _settings;

    public AttackState(CharacterStateMachineSettings settings, Attacker attacker) : base(
        new List<Transition>
        {
            new TargetLost(settings)
        })
    {
        _attacker = attacker;
        _settings = settings;
    }

    public override void Enter()
    {
        _attacker.enabled = true;
        _attacker.SetTarget(_settings.CurrentTarget);
    }

    public override void Exit()
    {
        base.Exit();
        _attacker.enabled = false;
    }
}