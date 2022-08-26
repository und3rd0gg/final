using System.Collections.Generic;

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
        _attacker.Initialize(_settings.CurrentTarget);
        _attacker.enabled = true;
        
    }

    public override void Exit()
    {
        base.Exit();
        _attacker.enabled = false;
    }
}