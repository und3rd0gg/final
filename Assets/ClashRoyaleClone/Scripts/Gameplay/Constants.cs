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
    }
}