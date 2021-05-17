using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void PlayJump()
    {
        _animator.StopPlayback();
        _animator.Play("Jump");
    }
}
