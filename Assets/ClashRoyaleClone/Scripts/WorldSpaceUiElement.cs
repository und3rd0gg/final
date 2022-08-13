using UnityEngine;

public class WorldSpaceUiElement : MonoBehaviour
{
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        transform.LookAt(_camera.transform);

        if (gameObject.isStatic)
            this.enabled = false;
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform);
    }
}
