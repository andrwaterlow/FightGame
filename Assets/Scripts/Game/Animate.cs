using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovementAnimation(float speedZ, float speedX)
    {
        _animator.SetFloat("SpeedZ", speedZ);
        _animator.SetFloat("SpeedX", speedX);
    }

    public void SetAnimationDeath(bool IsAlive)
    {
        if (!IsAlive)
        {
            DeActiveAnimator();
        }
    }

    public void ActiveAnimator()
    {
        _animator.enabled = true;
    }

    public void DeActiveAnimator()
    {
        _animator.enabled = false;
    }

}
