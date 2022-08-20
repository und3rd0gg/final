using System.Collections.Generic;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MoveState : StateMachineBehaviour
{
    private Mover _mover;
    private IDetector _detector;
    private CharacterStateMachineSettings _settings;

    public MoveState(CharacterStateMachineSettings settings, Mover mover, IDetector detectorComponent) : base(
        new List<Transition>
        {
            new EnemyInVisionZone(mover.transform, settings),
        })
    {
        _mover = mover;
        _detector = detectorComponent;
        _settings = settings;
    }

    private void SetTarget(IAttackable target)
    {
        _settings.CurrentTarget = target;
        _mover.SetDestination(target.Position);
    }

    public override void Enter()
    {
        _mover.enabled = true;
        _detector.GameObjectDetected += OnGameObjectDetected;
        SetTarget(_settings.CurrentTarget);
    }

    public override void Exit()
    {
        base.Exit();
        _detector.GameObjectDetected -= OnGameObjectDetected;
        _mover.StopDestinationFollowing();
        _mover.enabled = false;
    }

    private void OnGameObjectDetected(GameObject detector, GameObject detectedObject)
    {
        if (detectedObject.TryGetComponent<IAttackable>(out var attackableObject))
        {
            SetTarget(attackableObject);
        }
    }
}