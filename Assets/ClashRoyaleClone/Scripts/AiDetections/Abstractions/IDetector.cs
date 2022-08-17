using System;
using UnityEngine;

namespace ClashRoyaleClone.Scripts.AiDetections.Abstractions
{
    public delegate void ObjectDetectionHandler(GameObject source, GameObject detectedObject);
    
    public interface IDetector
    {
        event ObjectDetectionHandler GameObjectDetected;
        event ObjectDetectionHandler GameObjectDetectionReleased;

        void Detect(IDetectable detectableObject);
        void Detect(GameObject detectedObject);
        void ReleaseDetection(IDetectable detectableObject);
        void ReleaseDetection(GameObject detectedObject);
    }
}