using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Tower _enemyTower;

    public void SpawnCharacter(Character character, Vector3 point)
    {
        var target = _mainCamera.ScreenPointToRay(point);

        if (Physics.Raycast(target, out var hit))
        {
            var currentCharacter = Instantiate(character);
            currentCharacter.Initialize(hit.point, _enemyTower);
        }
    }
}