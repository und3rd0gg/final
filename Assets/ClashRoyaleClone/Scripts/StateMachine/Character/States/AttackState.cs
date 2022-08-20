using System.Collections.Generic;

public class AttackState : StateMachineBehaviour
{
    private Attacker _attacker;
    private CharacterStateMachineSettings _settings;

    public AttackState(CharacterStateMachineSettings settings, Attacker attacker) : base(
        new List<Transition>()
        {
            new TargetLost(settings),
        })
    {
        _attacker = attacker;
        _settings = settings;
    }

    public override void Enter()
    {
        _attacker.SetTarget(_settings.CurrentTarget);
        _attacker.enabled = true;
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        _attacker.enabled = false;
    }
}