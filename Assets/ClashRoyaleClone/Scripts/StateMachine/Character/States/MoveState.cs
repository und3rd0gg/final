using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MoveState : StateMachineBehaviour
{
    private Animator _animator;
    private Mover _mover;
    private Vector3 _target;

    public MoveState(Mover mover, Animator animator, BoxCollider visionZone, Vector3 target) : base(
        new List<Transition>
        {
            new EnemyInVisionZone(visionZone),
        })
    {
        _mover = mover;
        //Transitions.Add(new EnemyInVisionZone());
        _animator = animator;
        SetTarget(target);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    public override void Enter()
    {
        _mover.SetDestination(_target);
    }

    public override void Exit()
    {
        _mover.StopDestinationFollowing();
    }
}