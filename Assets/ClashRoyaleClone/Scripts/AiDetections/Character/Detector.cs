using System;
using System.Collections.Generic;
using ClashRoyaleClone.Scripts.AiDetections.Abstractions;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Detector : MonoBehaviour, IDetector
{
    private List<GameObject> _detectedObjects = new List<GameObject>();

    public GameObject[] DetectedObjects => _detectedObjects.ToArray();

    public event Action<GameObject, GameObject> GameObjectDetected;
    public event Action<GameObject, GameObject> GameObjectDetectionReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (IsDetectableObject(other, out var detectedObject))
        {
            Detect(detectedObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsDetectableObject(other, out var detectedObject))
        {
            ReleaseDetection(detectedObject);
        }
    }

    private bool IsDetectableObject(Collider coll, out IDetectable detectedObject)
    {
        detectedObject = GetComponentInParent<IDetectable>();
        return detectedObject != null;
    }

    public void Detect(IDetectable detectableObject)
    {
        if (!_detectedObjects.Contains(detectableObject.GameObject))
        {
            detectableObject.Detected(gameObject);
            _detectedObjects.Add(detectableObject.GameObject);
            GameObjectDetected?.Invoke(gameObject, detectableObject.GameObject);
        }
    }

    public void Detect(GameObject detectedObject)
    {
        if (!_detectedObjects.Contains(detectedObject))
        {
            _detectedObjects.Add(detectedObject);
            GameObjectDetected?.Invoke(gameObject, detectedObject);
        }
    }

    public void ReleaseDetection(IDetectable detectableObject)
    {
        if (_detectedObjects.Contains(detectableObject.GameObject))
        {
            detectableObject.DetectionReleased(gameObject);
            _detectedObjects.Remove(detectableObject.GameObject);
            GameObjectDetectionReleased?.Invoke(gameObject, detectableObject.GameObject);
        }
    }

    public void ReleaseDetection(GameObject detectedObject)
    {
        if (_detectedObjects.Contains(detectedObject))
        {
            _detectedObjects.Remove(detectedObject);
            GameObjectDetectionReleased?.Invoke(gameObject, detectedObject);
        }
    }
}