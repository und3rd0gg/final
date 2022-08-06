using UnityEngine;

public class Character : CharacterStateMachine, IAttackable
{
    public Vector3 Position => transform.position;
    
    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }
}