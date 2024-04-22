using System;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action AttackAnimationFinished;

    public void FinishAnimationAttack()
    {
        AttackAnimationFinished?.Invoke();
    }
}
