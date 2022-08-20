using System;

public class Health : CharacterCharacteristic
{
    public event Action<int> Decreased; 

    public void ApplyDamage(int damage)
    {
        Amount -= damage;
        Decreased?.Invoke(Amount);
    }
}