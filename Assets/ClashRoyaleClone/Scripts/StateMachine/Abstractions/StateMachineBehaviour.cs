using System.Collections.Generic;

namespace ClashRoyaleClone.Scripts.StateMachine.Abstractions
{
    public abstract class StateMachineBehaviour
    {
        protected List<Transition> Transitions;

        public StateMachineBehaviour()
        {
            Transitions = new List<Transition>();
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
}