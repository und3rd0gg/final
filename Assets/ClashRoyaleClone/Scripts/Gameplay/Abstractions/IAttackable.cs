﻿using UnityEngine;

public interface IAttackable
{
    Vector3 Position { get; }

    void ApplyDamage(int damage);
}