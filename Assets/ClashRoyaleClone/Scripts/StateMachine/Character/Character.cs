using UnityEngine;

public class Character : CharacterStateMachine, IAttackable
{
    private Health _health;

    [field: SerializeField] public int CreationPrice { get; private set; } = 1;
    [field: SerializeField] public Sprite Icon { get; private set; }

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