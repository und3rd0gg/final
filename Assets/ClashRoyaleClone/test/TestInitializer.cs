using UnityEngine;

public class TestInitializer : MonoBehaviour
{
    [SerializeField] private Tower _mainTarget;
    
    private void Awake()
    {
        GetComponent<Character>().Initialize(transform.position, _mainTarget);
    }
}
