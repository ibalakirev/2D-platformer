using System;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    public event Action AttackAnimationFinished;

    public void FinishAnimationAttack()
    {
        AttackAnimationFinished?.Invoke();
    }
}