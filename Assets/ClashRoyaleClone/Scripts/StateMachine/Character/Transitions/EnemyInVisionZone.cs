using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

public class EnemyInVisionZone : Transition
{
    private IDetector _detector;
    
    public EnemyInVisionZone(IDetector detectorComponent)
    {
        _detector = detectorComponent;
        _detector.GameObjectDetected += OnGameObjectDetected;
    }

    private void OnGameObjectDetected(GameObject detector, GameObject detectedObject)
    {
        
    }

    public override void Tick()
    {
        //if()
    }
}