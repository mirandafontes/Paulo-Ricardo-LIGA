using UnityEngine;

namespace Gawr.Misc
{
    /// <summary>
    /// Classe contendo strings e seus hashes.
    /// </summary>
    public static class Words
    {
        public static readonly string AnimatorSpeedWord = "Speed";
        public static readonly int AnimatorSpeedHash = Animator.StringToHash(AnimatorSpeedWord);
        public static readonly string AnimatorIsJumpingWord= "IsJumping";
        public static readonly int AnimatorIsJumpingHash = Animator.StringToHash(AnimatorIsJumpingWord);
    }
}