using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCreationButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private PlayerWarning _playerWarning;
    [SerializeField] private MoneyBalance _moneyBalance;
    [SerializeField] private Tower _mainTarget;
    [SerializeField] private Character _character;
    [SerializeField] private Image _characterIconImage;
    [SerializeField] private TMP_Text _price;
    [Range(0f, 5f)] [SerializeField] private float _offsetDelta = 0;

    private Character _currentCharacter;
    private Vector3 _currentCharacterCreationPosition;
    private Camera _camera;

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
        if (_moneyBalance.TrySpend(_character.CreationPrice))
        {
            _currentCharacter = Instantiate(_character);
        }
        else
        {
            _playerWarning.Show("You have not enough money!");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_currentCharacter == null)
            return;

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
        if (_currentCharacter == null)
            return;

        if (!_currentCharacter.CanSpawn)
        {
            _moneyBalance.Add(_currentCharacter.CreationPrice);
            Destroy(_currentCharacter.gameObject);
            return;
        }

        _currentCharacter.Initialize(_currentCharacterCreationPosition, PlaySide.Player,  _mainTarget);
        _currentCharacter = null;
    }
}