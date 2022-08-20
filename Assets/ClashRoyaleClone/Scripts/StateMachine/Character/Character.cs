using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : CharacterStateMachine, IAttackable
{
    private Health _health;
    private Animator _animator;

    [field: SerializeField] public int CreationPrice { get; private set; } = 1;
    [field: SerializeField] public Sprite Icon { get; private set; }
    
    public Vector3 Position => transform.position;
    public bool IsAlive => gameObject.activeInHierarchy;

    protected void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
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
        _animator.SetTrigger(AnimatorCharacterController.Params.Hit);
    }
    
    private void OnHealthEnded()
    {
        _animator.SetBool(AnimatorCharacterController.Params.IsDead, true);
        _animator.Play("Death");
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
        InitializeBehaviorMap();
    }
}