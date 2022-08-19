using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

public class DetectableObject : MonoBehaviour, IDetectable
{
    public event ObjectDetectionHandler GameObjectDetected;
    public event ObjectDetectionHandler GameObjectDetectionReleased;
    public GameObject GameObject => gameObject;

    public void Detected(GameObject source)
    {
        GameObjectDetected?.Invoke(source, gameObject);
    }

    public void DetectionReleased(GameObject source)
    {
        GameObjectDetectionReleased?.Invoke(source, gameObject);
    }
}