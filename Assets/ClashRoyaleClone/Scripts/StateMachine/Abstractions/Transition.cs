using System;

public abstract class Transition
{
    public bool IsReadyToTransit { get; protected set; } = false;
    public Type TargetBehaviour { get; protected set; }

    public abstract void Tick();

    public virtual void Reset()
    {
        IsReadyToTransit = false;
    }
}