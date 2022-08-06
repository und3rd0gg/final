using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _currentDestination;
    private Coroutine _waitUntilTargetReachedRoutine;
    private Animator _animator;

    public event Action DestinationReached;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var currentVelocity = _navMeshAgent.velocity.magnitude;
        _animator.SetFloat(AnimatorCharacterController.Params.Speed, currentVelocity);
    }

    private IEnumerator WaitUntilTargetReachedRoutine()
    {
        if (_navMeshAgent.hasPath && _navMeshAgent.velocity.sqrMagnitude > 0)
        {
            yield return new WaitUntil(() => _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance);
            DestinationReached?.Invoke();
        }
    }

    public void SetDestination(Vector3 destination)
    {
        _currentDestination = destination;
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(_currentDestination);
        _waitUntilTargetReachedRoutine = StartCoroutine(WaitUntilTargetReachedRoutine());
    }

    public void StopDestinationFollowing()
    {
        if (_waitUntilTargetReachedRoutine != null)
        {
            StopCoroutine(_waitUntilTargetReachedRoutine);
        }

        _navMeshAgent.isStopped = true;
        enabled = false;
    }
}