using System.Collections.Generic;
using ClashRoyaleClone.Scripts.Game;
using ClashRoyaleClone.Scripts.StateMachine.Abstractions;
using UnityEngine;
using UnityEngine.AI;
using StateMachineBehaviour = ClashRoyaleClone.Scripts.StateMachine.Abstractions.StateMachineBehaviour;

namespace ClashRoyaleClone.Scripts.StateMachine.Character.States
{
    public class MoveState : StateMachineBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Rigidbody _rigidbody;
        private Vector3 _target;
    
        public MoveState(NavMeshAgent navMeshAgent, Animator animator, Vector3 target)
        {
            Transitions = new List<Transition>();
            //Transitions.Add();
            _animator = animator;
            _navMeshAgent = navMeshAgent;
            SetTarget(target);
        }

        public void SetTarget(Vector3 target)
        {
            _target = target;
        }

        public override void Enter()
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_target);
        }

        public override void Tick()
        {
            base.Tick();
            var currentVelocity = _navMeshAgent.velocity.magnitude;
            _animator.SetFloat(AnimatorCharacterController.Params.Speed, currentVelocity);
        }

        public override void Exit()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}