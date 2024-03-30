
using UnityEngine;

[RequireComponent(typeof(PatrollerEnemy), typeof(MoverEnemy), typeof(EnemyVision))]

public class StalkerEnemy : MonoBehaviour
{
    private PatrollerEnemy _patrollerEnemy;
    private MoverEnemy _moverEnemy;
    private EnemyVision _enemyVision;

    private void Start()
    {
        _patrollerEnemy = GetComponent<PatrollerEnemy>();
        _moverEnemy = GetComponentInParent<MoverEnemy>();
        _enemyVision = GetComponentInParent<EnemyVision>(); 
    }

    public void ChasePlayer(Vector2 offset )
    {
        float nullValueDistance = 0;
        float valueLeftDirection = -1;
        float minValueDistance = 0.2f;
        float distance = 0;

        if(_enemyVision.IsPlayerSaw == true)
        {
            distance = _enemyVision.CurrentHitObject.transform.position.x - transform.position.x;
        }

        if (distance < nullValueDistance)
        {
            offset *= valueLeftDirection;
        }

        if (GetStatusDirectionEnemy(distance, minValueDistance, _patrollerEnemy.IsFaicingRight == false ||
            GetStatusDirectionEnemy(minValueDistance, distance, _patrollerEnemy.IsFaicingRight == true)))
        {
            _patrollerEnemy.Flip();
        }

        _moverEnemy.MovePositionEnemy(offset);
    }

    private bool GetStatusDirectionEnemy(float firstValueDistance, float secondValueDistance, bool isFaicingRight)
    {
        return firstValueDistance > secondValueDistance && isFaicingRight;
    }
}
