using System.Collections.Generic;
using System.Linq;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MoveState : StateMachineBehaviour
{
    private Mover _mover;
    private IDetector _detector;
    private IAttackable _target;

    public MoveState(Mover mover, ref IAttackable target, IDetector detectorComponent) : base(
        new List<Transition>
        {
            new EnemyInVisionZone(mover.transform, ref target),
        })
    {
        _mover = mover;
        _detector = detectorComponent;
        _target = target;
    }

    private void SetTarget(IAttackable target)
    {
        _target = target;
        _mover.SetDestination(_target.Position);
        UpdateTargetInVisionZoneTransition(_target);
    }

    public override void Enter()
    {
        _detector.GameObjectDetected += OnGameObjectDetected;
        SetTarget(_target);
    }

    public override void Exit()
    {
        _detector.GameObjectDetected -= OnGameObjectDetected;
        _mover.StopDestinationFollowing();
    }

    private void OnGameObjectDetected(GameObject detector, GameObject detectedObject)
    {
        if (detectedObject.TryGetComponent<IAttackable>(out var attackableObject))
        {
            SetTarget(attackableObject);
        }
    }

    private void UpdateTargetInVisionZoneTransition(IAttackable target)
    {
        foreach (var currentTransition in Transitions
                     .Where(transition => transition.GetType() == typeof(EnemyInVisionZone)).Cast<EnemyInVisionZone>())
        {
            currentTransition.Target = _target;
        }
    }
}