using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [Min(1)] [SerializeField] private int _damage = 10;

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

    private IEnumerator FightRoutine()
    {
        while (enabled)
        {
            _animator.Play(ChooseRandomAnimation());
            _target.ApplyDamage(_damage);
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

    public void Initialize(IDamagable target)
    {
        _target = target;
        enabled = true;
        _attackRoutine = StartCoroutine(FightRoutine());
    }
}