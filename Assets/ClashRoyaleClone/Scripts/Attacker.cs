using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [Min(1)] [SerializeField] private int _damage = 10;

    private Animator _animator;
    private IAttackable _target;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(FightRoutine());
    }

    private void Reset()
    {
        enabled = false;
    }

    private IEnumerator FightRoutine()
    {
        while (enabled)
        {
            _animator.SetTrigger(AnimatorCharacterController.Params.PunchRight);
            _target.ApplyDamage(_damage);
            var animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);
        }
    }

    public void SetTarget(IAttackable target)
    {
        _target = target;
    }
}