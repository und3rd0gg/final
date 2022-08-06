using UnityEngine;

public class Tower : MonoBehaviour, IAttackable
{
    public Vector3 Position => transform.position;
}