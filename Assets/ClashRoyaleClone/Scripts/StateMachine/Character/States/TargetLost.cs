public class TargetLost : Transition
{
    private CharacterStateMachineSettings _settings;
    
    public TargetLost(CharacterStateMachineSettings settings)
    {
        _settings = settings;
    }
    
    public override void Tick()
    {
        
    }
}