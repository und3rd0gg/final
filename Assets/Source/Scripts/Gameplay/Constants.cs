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

    public static class States
    {
        public static readonly int PunchLeft = Animator.StringToHash("PunchLeft");
        public static readonly int PunchRight = Animator.StringToHash("PunchLeft");
        public static readonly int Hit = Animator.StringToHash("Hit");
        public static readonly int Death = Animator.StringToHash("Death");
        public static readonly int Run = Animator.StringToHash("Run/Sprint");
    }
}

public static class AnimatorPlayerWarningContoller
{
    public static class States
    {
        public static readonly int FadeIn = Animator.StringToHash("FadeIn");
    }
}

public static class AnimatorUiWidgetMenuCanvasController
{
    public class States
    {
        public static readonly int FadeIn = Animator.StringToHash("FadeIn");
    }
}