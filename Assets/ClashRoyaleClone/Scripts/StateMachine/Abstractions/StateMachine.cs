using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClashRoyaleClone.Scripts.StateMachine.Abstractions
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected Dictionary<Type, StateMachineBehaviour> CharacterBehaviorsMap;
        private StateMachineBehaviour _currentBehaviour;

        private void Awake()
        {
            InitializeBehaviorMap();
        }
    
        private void Update()
        {
            if (_currentBehaviour == null)
                return;

            _currentBehaviour?.Tick();
            var nextBehavior = _currentBehaviour.GetNextBehavior();
            //SetBehaviour<>();
        }

        protected void SetBehaviourByDefault<T>() where T : StateMachineBehaviour
        {
            SetBehaviour<T>();
        }

        protected void SetBehaviour<T>() where T : StateMachineBehaviour
        {
            _currentBehaviour?.Exit();
            _currentBehaviour = GetBehavior<T>();
            _currentBehaviour.Enter();
        }

        protected StateMachineBehaviour GetBehavior<T>() where T : StateMachineBehaviour
        {
            var type = typeof(T);
            return CharacterBehaviorsMap[type];
        }

        protected abstract void InitializeBehaviorMap();
    }
}