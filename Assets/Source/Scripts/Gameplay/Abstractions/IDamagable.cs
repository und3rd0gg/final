using UnityEngine;

public interface IDamagable
{
    PlaySide PlaySide { get; }

    Vector3 Position { get; }

    bool IsAlive { get; }

    void ApplyDamage(int damage);
}