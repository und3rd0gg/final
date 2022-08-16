using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCreationButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Tower _mainTarget;
    [SerializeField] private Character _character;
    [SerializeField] private Image _characterIconImage;
    [SerializeField] private TMP_Text _price;
    [Range(0f, 5f)]
    [SerializeField] private float _offsetDelta = 0;
    
    private Character _currentCharacter;
    private Vector3 _currentCharacterCreationPosition;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Reset()
    {
        _price = GetComponentInChildren<TMP_Text>();
        _characterIconImage = GetComponentsInChildren<Image>()[1];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _currentCharacter = Instantiate(_character);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var spawnDestination = _camera.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(spawnDestination, out var hit))
        {
            _currentCharacterCreationPosition = hit.point;
            var dragPoint = hit.point;
            dragPoint.y += _offsetDelta;
            _currentCharacter.transform.position = dragPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _currentCharacter.Initialize(_currentCharacterCreationPosition, _mainTarget);
    }
}