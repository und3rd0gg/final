using UnityEngine;

public class EnemyInVisionZone : Transition
{
    public IAttackable Target;
    
    private Transform _characterTransform;
    private readonly float _stopDistance = 2.2f;

    public EnemyInVisionZone(Transform characterTransform, ref IAttackable target)
    {
        TargetBehaviour = typeof(AttackState);
        _characterTransform = characterTransform;
        Target = target;
    }

    public override void Tick()
    {
        if (Vector3.Distance(_characterTransform.position, Target.Position) < _stopDistance)
        {
            IsReadyToTransit = true;
        }
    }
}