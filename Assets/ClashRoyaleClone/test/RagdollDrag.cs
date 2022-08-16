using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RagdollDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Character _character;
    private Character _currentCharacter;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _currentCharacter = Instantiate(_character);
        var rb = _currentCharacter.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var target = Camera.main.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(target, out var hit))
        {
            Debug.Log(hit.transform.name);
            var dragPoint = hit.point;
            dragPoint.y += 5;
            _currentCharacter.transform.position = dragPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _currentCharacter.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
