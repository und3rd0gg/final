using System;
using System.Collections.Generic;

public abstract class StateMachineBehaviour
{
    protected List<Transition> Transitions { get; private set; }

    protected StateMachineBehaviour(List<Transition> transitions = null)
    {
        Transitions = transitions;
    }

    public Type GetNextBehavior()
    {
        foreach (var transition in Transitions)
        {
            if (transition.IsReadyToTransit)
            {
                return transition.TargetBehaviour;
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