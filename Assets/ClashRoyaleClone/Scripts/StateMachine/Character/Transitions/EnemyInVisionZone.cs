using UnityEngine;

public class EnemyInVisionZone : Transition
{
    private CharacterStateMachineSettings _settings;
    private Transform _characterTransform;
    private readonly float _stopDistance = 2.2f;

    public EnemyInVisionZone(Transform characterTransform, CharacterStateMachineSettings settings)
    {
        TargetBehaviour = typeof(AttackState);
        _characterTransform = characterTransform;
        _settings = settings;
    }

    public override void Tick()
    {
        if (Vector3.Distance(_characterTransform.position, _settings.CurrentTarget.Position) < _stopDistance)
        {
            IsReadyToTransit = true;
        }
    }
}