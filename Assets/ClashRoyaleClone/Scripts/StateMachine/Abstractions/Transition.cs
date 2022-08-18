public abstract class Transition
{
    private bool _isActivated;
    
    public bool IsReadyToTransit { get; protected set; } = false;
    public StateMachineBehaviour targetBehaviour;

    public abstract void Tick();
}