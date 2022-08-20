using UnityEngine;

public static class Axes
{
    public const string Horizontal = nameof(Horizontal);
    public const string Vertical = nameof(Vertical);
}

public static class AnimatorCharacterController
{
    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash("Speed");
        public static readonly int PunchLeft = Animator.StringToHash("PunchLeft");
        public static readonly int PunchRight = Animator.StringToHash("PunchLeft");
        public static readonly int IsDead = Animator.StringToHash("IsDead");
        public static readonly int Hit = Animator.StringToHash("Hit");
    }
}