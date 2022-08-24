using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreationZone : MonoBehaviour
{
    [field: SerializeField] public PlaySide PlaySide { get; private set; }

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public Vector3 GetRandomLocation()
    {
        var bounds = _collider.bounds;

        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z));
    }
    
    private void Reset()
    {
        var parent = GetComponentInParent<IDamagable>();
        
        if (parent != null)
        {
            PlaySide = parent.PlaySide;
        }
    }
}
