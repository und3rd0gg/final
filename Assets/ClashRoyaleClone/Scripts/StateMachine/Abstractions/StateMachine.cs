using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected Dictionary<Type, StateMachineBehaviour> BehaviorMap;
    private StateMachineBehaviour _currentBehaviour;

    protected virtual void Start()
    {
        InitializeBehaviorMap();
    }

    protected virtual void Update()
    {
        _currentBehaviour?.Tick();

        var nextBehaviour = _currentBehaviour.GetNextBehavior();

        if (nextBehaviour != null)
        {
            SetBehaviour(nextBehaviour);
        }
    }

    protected void SetBehaviourByDefault<T>() where T : StateMachineBehaviour
    {
        SetBehaviour<T>();
    }

    protected void SetBehaviour<T>() where T : StateMachineBehaviour
    {
        _currentBehaviour?.Exit();
        _currentBehaviour = GetBehaviour<T>();
        _currentBehaviour.Enter();
    }

    protected void SetBehaviour(Type behaviourType)
    {
        _currentBehaviour?.Exit();
        _currentBehaviour = GetBehaviour(behaviourType);
        _currentBehaviour.Enter();
    }

    protected void SetBehaviour(StateMachineBehaviour behavior)
    {
        _currentBehaviour?.Exit();
        _currentBehaviour = behavior;
        _currentBehaviour.Enter();
    }

    protected StateMachineBehaviour GetBehaviour<T>() where T : StateMachineBehaviour
    {
        var type = typeof(T);
        return BehaviorMap[type];
    }

    protected StateMachineBehaviour GetBehaviour(Type behaviourType)
    {
        return BehaviorMap[behaviourType];
    }

    protected abstract void InitializeBehaviorMap();
}