using System;
using UnityEngine;

public interface IDetectable
{
    event Action<GameObject, GameObject> GameObjectDetected;
    event Action<GameObject, GameObject> GameObjectDetectionReleased;

    GameObject GameObject { get; }

    void Detected(GameObject source);
    void DetectionReleased(GameObject source);
}