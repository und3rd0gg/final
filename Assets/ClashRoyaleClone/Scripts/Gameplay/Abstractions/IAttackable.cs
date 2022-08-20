using UnityEngine;

public interface IAttackable
{
    Vector3 Position { get; }
    bool IsAlive { get; }
        
    void ApplyDamage(int damage);
}