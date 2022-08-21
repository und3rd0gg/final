public class TargetLost : Transition
{
    private CharacterStateMachineSettings _settings;
    
    public TargetLost(CharacterStateMachineSettings settings)
    {
        TargetBehaviour = typeof(MoveState);
        _settings = settings;
    }

    public override void Tick()
    {
        if (!_settings.CurrentTarget.IsAlive)
        {
            _settings.CurrentTarget = _settings.MainTarget;
            IsReadyToTransit = true;
        }
    }
}