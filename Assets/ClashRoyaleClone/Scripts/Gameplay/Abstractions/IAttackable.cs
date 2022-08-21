using UnityEngine;

public interface IAttackable
{
    PlaySide PlaySide { get; }
    Vector3 Position { get; }
    bool IsAlive { get; }
        
    void ApplyDamage(int damage);
}