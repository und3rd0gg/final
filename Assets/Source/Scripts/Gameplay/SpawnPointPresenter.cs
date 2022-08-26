using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpawnPointPresenter : MonoBehaviour
{
    [SerializeField] private Vector3 _deltaPosition;
    [SerializeField] private Character _character;
    
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_character.CanSpawn(out var spawnPoint))
        {
            _spriteRenderer.enabled = true;
            transform.position = spawnPoint + _deltaPosition;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
    }
}
