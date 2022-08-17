using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInitializer : MonoBehaviour
{
    [SerializeField] private Tower _mainTarget;
    
    private void Awake()
    {
        GetComponent<Character>().Initialize(transform.position, _mainTarget);
    }
}
