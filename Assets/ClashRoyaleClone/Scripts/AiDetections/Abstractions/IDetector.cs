using System;
using UnityEngine;

namespace ClashRoyaleClone.Scripts.AiDetections.Abstractions
{
    public interface IDetector
    {
        event Action<GameObject, GameObject> GameObjectDetected;
        event Action<GameObject, GameObject> GameObjectDetectionReleased;

        void Detect(IDetectable detectableObject);
        void Detect(GameObject detectedObject);
        void ReleaseDetection(IDetectable detectableObject);
        void ReleaseDetection(GameObject detectedObject);
    }
}