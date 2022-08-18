using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Animator _animator;
    private IAttackable _target;

    public AttackState(IAttackable target, Animator animator) : base()
    {
        _animator = animator;
        _target = target;
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}