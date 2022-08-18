using UnityEngine;

public class EnemyInVisionZone : Transition
{
    private Transform _characterTransform;
    private IAttackable _target;
    private readonly float _stopDistance = 1.6f;

    public EnemyInVisionZone(Transform characterTransform, ref IAttackable target)
    {
        _characterTransform = characterTransform;
        _target = target;
    }

    public override void Tick()
    {
        Debug.Log(_target);
        
        if (Vector3.Distance(_characterTransform.position, _target.Position) < _stopDistance)
        {
            Debug.Log(Vector3.Distance(_characterTransform.position, _target.Position));
            IsReadyToTransit = true;
        }
    }
}