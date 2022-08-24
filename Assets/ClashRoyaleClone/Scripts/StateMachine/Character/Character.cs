using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Character : CharacterStateMachine, IDamagable
{
    private Animator _animator;
    private Health _health;
    private Rigidbody _rigidbody;

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public int CreationPrice { get; private set; } = 1;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // _health.Decreased += OnHealthDecreased;
        _health.AmountEndedEvent += OnHealthEnded;
    }

    private void OnDisable()
    {
        //_health.Decreased -= OnHealthDecreased;
        _health.AmountEndedEvent -= OnHealthEnded;
    }

    [field: SerializeField] public PlaySide PlaySide { get; private set; }

    public bool IsAlive => enabled;
    public Vector3 Position => transform.position;

    public void ApplyDamage(int damage)
    {
        _health.ApplyDamage(damage);
    }

    public void Initialize(Vector3 position, IDamagable mainTarget)
    {
        transform.position = position;
        Settings = new CharacterStateMachineSettings(PlaySide, mainTarget);
        enabled = true;
        _rigidbody.constraints = RigidbodyConstraints.None;
        InitializeBehaviorMap();
    }

    private void OnHealthDecreased(int amount)
    {
        _animator.Play(AnimatorCharacterController.States.Hit);
    }

    private void OnHealthEnded()
    {
        Exit();
        _animator.Play(AnimatorCharacterController.States.Death);
        enabled = false;
    }
}

public enum PlaySide
{
    Player,
    Enemy
}