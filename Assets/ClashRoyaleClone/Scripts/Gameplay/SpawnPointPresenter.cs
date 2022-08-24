using UnityEngine;

public class SpawnPointPresenter : MonoBehaviour
{
    [SerializeField] private Vector3 _deltaPosition;
    
    private SpriteRenderer _spriteRenderer;
    private Transform _parent;

    private void Awake()
    {
        _parent = transform.parent;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var collided = Physics.Raycast(_parent.position, Vector3.down, out var hitInfo);

        if (collided)
        {
            if (hitInfo.transform.GetComponent<CreationZone>() != null)
            {
                _spriteRenderer.enabled = true;
                Debug.Log(hitInfo.transform.name);
                transform.position = hitInfo.point;
                transform.position += _deltaPosition;
            }
            else
            {
                _spriteRenderer.enabled = false;
            }
        }
    }
}
