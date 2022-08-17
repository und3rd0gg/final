using System.Collections.Generic;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MoveState : StateMachineBehaviour
{
    private Mover _mover;
    private Vector3 _target;
    private IDetector _detector;

    public MoveState(Mover mover, Vector3 target, IDetector detectorComponent) : base(
        new List<Transition>
        {
            //new EnemyInVisionZone(visionZone),
        })
    {
        _mover = mover;
        _detector = detectorComponent;
        SetTarget(target);
    }

    private void OnGameObjectDetected(GameObject detector, GameObject detectedObject)
    {
        if (detectedObject.TryGetComponent<IAttackable>(out var attackableObject))
        {
            SetTarget(attackableObject.Position);
            _mover.SetDestination(_target);
        }
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    public override void Enter()
    {
        base.Enter();
        _detector.GameObjectDetected += OnGameObjectDetected;
        _mover.SetDestination(_target);
    }

    public override void Exit()
    {
        base.Exit();
        _detector.GameObjectDetected -= OnGameObjectDetected;
        _mover.StopDestinationFollowing();
    }
}