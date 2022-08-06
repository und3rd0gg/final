using UnityEngine;

[RequireComponent(typeof(Health))]
public class Character : CharacterStateMachine, IAttackable
{
    private Health _health;

    protected void Awake()
    {
        _health = GetComponent<Health>();
    }

    public Vector3 Position => transform.position;

    public void ApplyDamage(int damage)
    {
        _health.ApplyDamage(damage);
    }

    public void Initialize(Vector3 position, IAttackable mainTarget)
    {
        transform.position = position;
        MainTarget = mainTarget;
    }
}