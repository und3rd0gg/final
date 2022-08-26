using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner: MonoBehaviour
{
    [SerializeField] private Tower _mainTarget;
    [SerializeField] private CreationZone _creationZone;
    [SerializeField] private Character[] _characters;
    [SerializeField] [Min(1)] private float _spawnDelay = 1;
    [SerializeField] [Min(1)] private float _spawnDelayDecreaseTime = 1;
    [SerializeField] private float _spawnDelayDecreaseValue = 1;

    private void OnEnable()
    {
        StartCoroutine(EnemyCreationRoutine());
        StartCoroutine(DecreaseSpawnDelayRoutine());
    }

    private IEnumerator EnemyCreationRoutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_spawnDelay);
            var charachterToSpawn = SelectRandomCharacter();
            var charachter = Instantiate(charachterToSpawn);
            charachter.Initialize(_creationZone.GetRandomLocation(), _creationZone.PlaySide, _mainTarget);
        }
    }

    private IEnumerator DecreaseSpawnDelayRoutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_spawnDelayDecreaseTime);
            _spawnDelay -= _spawnDelayDecreaseValue;
        }
    }

    private Character SelectRandomCharacter()
    {
        var charachterIndex = Random.Range(0, _characters.Length);
        return _characters[charachterIndex];
    }
}