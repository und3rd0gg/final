using UnityEngine;

public class Tower : MonoBehaviour, IAttackable
{
    public Vector3 Position => transform.position;
    public void ApplyDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}