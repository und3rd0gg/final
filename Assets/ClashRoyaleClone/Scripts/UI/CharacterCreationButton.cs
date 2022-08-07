using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCreationButton : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Character _character;

    private CharacterSpawner _characterSpawner;

    private void Awake()
    {
        _characterSpawner = GetComponentInParent<CharacterSpawner>();
    }

    private void CreateCharacter()
    {
        _characterSpawner.SpawnCharacter(_character);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CreateCharacter();
    }

    public void OnDrag(PointerEventData eventData)
    { }
}