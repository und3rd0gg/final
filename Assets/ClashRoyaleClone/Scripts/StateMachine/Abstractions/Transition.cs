public abstract class Transition
{
    private bool _isActivated;
    
    public bool IsReadyToTransit { get; protected set; } = false;
    public StateMachineBehaviour targetBehaviour;

    public abstract void Tick();

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }
}