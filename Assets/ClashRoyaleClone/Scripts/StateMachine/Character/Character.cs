using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Character : CharacterStateMachine, IAttackable
{
    private Health _health;
    private Animator _animator;
    private Rigidbody _rigidbody;

    [field: SerializeField] public int CreationPrice { get; private set; } = 1;
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public PlaySide PlaySide { get; private set; }

    public Vector3 Position => transform.position;
    public bool IsAlive => gameObject.activeInHierarchy;

    protected void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //_health.Decreased += OnHealthDecreased;
        _health.AmountEndedEvent += OnHealthEnded;
    }

    private void OnDisable()
    {
        //_health.Decreased -= OnHealthDecreased;
        _health.AmountEndedEvent -= OnHealthEnded;
    }
    
    private void OnHealthDecreased(int amount)
    {
        _animator.Play(AnimatorCharacterController.States.Hit);
    }
    
    private void OnHealthEnded()
    {
        _animator.Play(AnimatorCharacterController.States.Death);
        enabled = false;
    }

    public void ApplyDamage(int damage)
    {
        _health.ApplyDamage(damage);
    }

    public void Initialize(Vector3 position, IAttackable mainTarget)
    {
        transform.position = position;
        Settings = new CharacterStateMachineSettings(mainTarget);
        this.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints.None;
        InitializeBehaviorMap();
    }
}

public enum PlaySide
{
    Player,
    Enemy
}