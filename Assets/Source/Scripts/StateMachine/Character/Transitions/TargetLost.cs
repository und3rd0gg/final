using UnityEngine;

public class TargetLost : Transition
{
    private CharacterStateMachineSettings _settings;
    private readonly float _targetLostDistance = 2.2f;
    
    public TargetLost(CharacterStateMachineSettings settings)
    {
        TargetBehaviour = typeof(MoveState);
        _settings = settings;
    }

    public override void Tick()
    {
        if (!IsTargetAvailable(_settings.CurrentTarget))
        {
            ReturnToMainTarget();
            IsReadyToTransit = true;
        }
    }

    private bool IsTargetAvailable(IDamagable target)
    {
        var distanceToTarget = Vector3.Distance(_settings.CharacterTransform.position, target.Position);

        if (!target.IsAlive || distanceToTarget > _targetLostDistance)
        {
            return false;
        }

        return true;
    }

    private void ReturnToMainTarget()
    {
        _settings.CurrentTarget = _settings.MainTarget;
    }
}