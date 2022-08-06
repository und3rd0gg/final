using UnityEngine;

public class Character : CharacterStateMachine, IAttackable
{
<<<<<<< HEAD
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
=======
    public Vector3 Position => transform.position;
    
    public void Initialize(Vector3 position)
>>>>>>> parent of 86143c6 (w)
    {
        transform.position = position;
        MainTarget = mainTarget;
    }
}