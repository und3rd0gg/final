using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Tower _enemyTower;

    private void Update()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var target = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(target, out var hit))
            {
                var character = Instantiate(_character);
                character.Initialize(hit.point, _enemyTower);
            }
        }
    }
}