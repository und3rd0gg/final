using System;
using UnityEngine;

public class CharacterCreationButton : MonoBehaviour
{
    private CharacterSpawner _characterSpawner;

    private void Awake()
    {
        _characterSpawner = GetComponentInParent<CharacterSpawner>();
    }
    
    
}
