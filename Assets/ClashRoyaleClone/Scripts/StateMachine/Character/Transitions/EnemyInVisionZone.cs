using UnityEngine;

public class EnemyInVisionZone : Transition
{
    private BoxCollider _visionZone;
    
    public EnemyInVisionZone(BoxCollider visionZone)
    {
        _visionZone = visionZone;
    }

    public override void Tick()
    {
        //if()
    }
}