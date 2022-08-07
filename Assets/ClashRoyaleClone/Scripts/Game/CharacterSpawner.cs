using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Tower _enemyTower;

    public void SpawnCharacter(Character character)
    {
        var target = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(target, out var hit))
        {
            var currentCharacter = Instantiate(character);
            currentCharacter.Initialize(hit.point, _enemyTower);
        }
    }
}