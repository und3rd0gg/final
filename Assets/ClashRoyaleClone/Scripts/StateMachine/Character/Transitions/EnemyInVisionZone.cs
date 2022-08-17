using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

public class EnemyInVisionZone : Transition
{
    private IDetector _detector;
    private readonly float _stopDistance = 1f;

    public EnemyInVisionZone(IDetector detectorComponent)
    {
        _detector = detectorComponent;
    }

    public override void Activate()
    {
        base.Activate();
        _detector.GameObjectDetected += OnGameObjectDetected;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _detector.GameObjectDetected -= OnGameObjectDetected;
    }

    public override void Tick()
    {
    }

    private void OnGameObjectDetected(GameObject detector, GameObject detectedObject)
    {
        if (detectedObject.TryGetComponent<IAttackable>(out var attackableObject))
        {
            
        }
    }

    private async void WaitUntilEnemyApproached()
    {
        
    }
}