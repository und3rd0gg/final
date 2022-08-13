using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCreationButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private CharacterSpawner _characterSpawner;
    [SerializeField] private Character _character;
    [SerializeField] private Image _characterIconImage;
    [SerializeField] private TMP_Text _tmpText;

    private Character _currentCharacter;

    private void Awake()
    {
        _characterIconImage.sprite = _character.Icon;
        _tmpText.text = _character.CreationPrice.ToString();
    }

    private void OnValidate()
    {
        if (_character != null && _characterIconImage != null) 
        {
            _characterIconImage.sprite = _character.Icon;
            _tmpText.text = _character.CreationPrice.ToString();
        }
    }

    private void CreateCharacter(Vector3 creationPoint)
    {
        _characterSpawner.SpawnCharacter(_character, creationPoint);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _currentCharacter = Instantiate(_character);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CreateCharacter(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentCharacter.transform.position = eventData.position;
    }
}