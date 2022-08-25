using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

public interface IDetectable
{
    event ObjectDetectionHandler GameObjectDetected;

    event ObjectDetectionHandler GameObjectDetectionReleased;

    GameObject GameObject { get; }

    void Detected(GameObject source);

    void DetectionReleased(GameObject source);
}