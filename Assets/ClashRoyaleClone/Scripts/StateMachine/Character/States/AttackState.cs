using ClashRoyaleClone.Scripts.Game;
using ClashRoyaleClone.Scripts.Game.Abstractions;
using UnityEngine;
using StateMachineBehaviour = ClashRoyaleClone.Scripts.StateMachine.Abstractions.StateMachineBehaviour;

namespace ClashRoyaleClone.Scripts.StateMachine.Character.States
{
    public class AttackState : StateMachineBehaviour
    {
        private Animator _animator;
        private IAttackable _target;

        public AttackState(IAttackable target, Animator animator)
        {
            _animator = animator;
            _target = target;
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}