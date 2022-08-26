using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.ExitGame());
    }
}
