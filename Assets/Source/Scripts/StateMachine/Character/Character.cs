using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Character : CharacterStateMachine, IDamagable
{
    [SerializeField] private SpawnPointPresenter _spawnPointPresenter;
    
    private Animator _animator;
    private Health _health;
    private Rigidbody _rigidbody;

    public bool IsAlive => _health.Amount > 0;
    
    public Vector3 Position => transform.position;

    [field: SerializeField] public Sprite Icon { get; private set; }
    
    [field: SerializeField] public PlaySide PlaySide { get; private set; }

    [field: SerializeField] public int CreationPrice { get; private set; } = 1;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _health.AmountEnded += OnHealthEnded;
    }

    private void OnDisable()
    {
        _health.AmountEnded -= OnHealthEnded;
    }

    public void ApplyDamage(int damage)
    {
        _health.ApplyDamage(damage);
    }

    public void Initialize(Vector3 position, PlaySide playSide, IDamagable mainTarget)
    {
        transform.position = position;
        PlaySide = playSide;
        Settings = new CharacterStateMachineSettings(transform, PlaySide, mainTarget);
        enabled = true;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        transform.LookAt(mainTarget.Position);
        InitializeBehaviorMap();
        _spawnPointPresenter.gameObject.SetActive(false);
    }

    public bool CanSpawn(out Vector3 point)
    {
        var collided = Physics.Raycast(transform.position, Vector3.down, out var hitInfo);
        point = hitInfo.point;

        if (collided)
            if (hitInfo.transform.TryGetComponent(out CreationZone creationZone))
                if (creationZone.PlaySide == PlaySide)
                    return true;

        return false;
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