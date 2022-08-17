using System.Collections.Generic;

public abstract class StateMachineBehaviour
{
    private List<Transition> Transitions;

    protected StateMachineBehaviour(List<Transition> transitions = null)
    {
        Transitions = transitions;
    }

    public StateMachineBehaviour GetNextBehavior()
    {
        foreach (var transition in Transitions)
        {
            if (transition.IsReadyToTransit)
            {
                return transition.targetBehaviour;
            }
        }

        return null;
    }

    public virtual void Enter()
    {
        foreach (var transition in Transitions)
        {
            transition.Activate();
        }
    }

    public virtual void Tick()
    {
        foreach (var transition in Transitions)
        {
            transition.Tick();
        }
    }

    public virtual void Exit()
    {
        foreach (var transition in Transitions)
        {
            transition.Deactivate();
        }
    }
}