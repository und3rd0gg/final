using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [Min(1)] [SerializeField] private int _basicDamage = 10;
    [Min(0)] [SerializeField] private int _damageSpread = 0;

    private Animator _animator;
    private IDamagable _target;
    private Coroutine _attackRoutine;
    private readonly int[] _punchAnimations =
        {AnimatorCharacterController.States.PunchLeft, AnimatorCharacterController.States.PunchRight};

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        StopCoroutine(_attackRoutine);
    }

    private void Reset()
    {
        enabled = false;
    }
    
    public void Initialize(IDamagable target)
    {
        _target = target;
        enabled = true;
        _attackRoutine = StartCoroutine(FightRoutine());
    }

    private IEnumerator FightRoutine()
    {
        while (enabled)
        {
            _animator.Play(ChooseRandomAnimation());
            _target.ApplyDamage(GetRandomDamage());
            var length = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(length);
        }
    }

    private int ChooseRandomAnimation()
    {
        var animationIndex = Random.Range(0, _punchAnimations.Length);
        var animation = _punchAnimations[animationIndex];
        return animation;
    }

    private int GetRandomDamage()
    {
        return Random.Range(_basicDamage - _damageSpread, _basicDamage + _damageSpread + 1);
    }
}