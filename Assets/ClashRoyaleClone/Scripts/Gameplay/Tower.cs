using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Tower : MonoBehaviour, IAttackable
{
    private Health _health;

    [field: SerializeField] public PlaySide PlaySide { get; private set; }
    public Vector3 Position => transform.position;
    public bool IsAlive => _health.Amount > 0;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void ApplyDamage(int damage)
    {
        _health.ApplyDamage(damage);
    }
}