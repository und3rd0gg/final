using UnityEngine;

public class Health : CharacterCharacteristic
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Amount -= 1;
        }
    }
}