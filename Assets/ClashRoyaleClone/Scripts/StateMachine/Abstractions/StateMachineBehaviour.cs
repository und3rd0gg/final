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

    public abstract void Enter();

    public virtual void Tick()
    {
        foreach (var transition in Transitions)
        {
            transition.Tick();
        }
    }

    public abstract void Exit();
}