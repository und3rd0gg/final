using UnityEngine;

namespace ClashRoyaleClone.Scripts.Game
{
    [RequireComponent(typeof(Camera))]
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Camera _camera;
        [SerializeField] private Enemy _enemy;


        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var target = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(target, out var hit))
                {
                    var character = Instantiate(_character);
                    character.Initialize(hit.point);
                }
            }
        }
    }
}