using UnityEngine;

public class WorldSpaceUiElement : MonoBehaviour
{
    [SerializeField] private bool flipY;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        transform.LookAt(_camera.transform);

        if (flipY)
            transform.rotation =
                Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);

        if (gameObject.isStatic)
            this.enabled = false;
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform);
    }
}