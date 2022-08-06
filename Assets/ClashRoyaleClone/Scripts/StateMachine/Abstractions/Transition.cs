public abstract class Transition
{
    public bool IsReadyToTransit { get; protected set; }

    public StateMachineBehaviour targetBehaviour;

    public abstract void Tick();
}