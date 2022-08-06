using System;
using UnityEngine;

namespace ClashRoyaleClone.Scripts.AiDetections.Abstractions
{
    public interface IDetectable
    {
        event Action<GameObject, GameObject> GameObjectDetected;
        event Action<GameObject, GameObject> GameObjectDetectionReleased;
        
        GameObject GameObject { get; }

        void Detected(GameObject source);
        void DetectionReleased(GameObject source);
    }
}