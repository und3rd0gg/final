using System;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;

namespace ClashRoyaleClone.Scripts.AiDetections.Character
{
    public class DetectableObject : MonoBehaviour, IDetectable
    {
        public event Action<GameObject, GameObject> GameObjectDetected;
        public event Action<GameObject, GameObject> GameObjectDetectionReleased;
        public GameObject GameObject { get; }
        public void Detected(GameObject source)
        {
            GameObjectDetected?.Invoke(source, gameObject);
        }

        public void DetectionReleased(GameObject source)
        {
            GameObjectDetectionReleased?.Invoke(source, gameObject);
        }
    }
}