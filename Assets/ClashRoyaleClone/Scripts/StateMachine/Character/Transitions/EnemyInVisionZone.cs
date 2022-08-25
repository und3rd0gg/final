using UnityEngine;

public class EnemyInVisionZone : Transition
{
    private CharacterStateMachineSettings _settings;
    private readonly float _stopDistance = 2.2f;

    public EnemyInVisionZone(CharacterStateMachineSettings settings)
    {
        TargetBehaviour = typeof(AttackState);
        _settings = settings;
    }

    public override void Tick()
    {
        if (Vector3.Distance(_settings.CharacterTransform.position, _settings.CurrentTarget.Position) < _stopDistance)
        {
            IsReadyToTransit = true;
        }
    }
}