
using UnityEngine;

[RequireComponent(typeof(PatrollerEnemy), typeof(MoverEnemy))]

public class StalkerEnemy : MonoBehaviour
{
    private PatrollerEnemy _patrollerEnemy;
    private MoverEnemy _moverEnemy;
    private MovePlayer _movePlayer;

    private void Start()
    {
        _patrollerEnemy = GetComponent<PatrollerEnemy>();
        _moverEnemy = GetComponentInParent<MoverEnemy>();
        _movePlayer = FindObjectOfType<MovePlayer>();   
    }

    public void ChasePlayer(Vector2 nextPoint, bool isFaicingRight)
    {
        float nullValueDistance = 0;
        float valueLeftDirection = -1;
        float minValueDistance = 0.2f;
        float distance = _movePlayer.transform.position.x - transform.position.x;

        if (distance < nullValueDistance)
        {
            nextPoint *= valueLeftDirection;
        }

        if (GetStatusDirectionEnemy(distance, minValueDistance, isFaicingRight == false))
        {
            _patrollerEnemy.Flip();
        }
        else if (GetStatusDirectionEnemy(minValueDistance, distance, isFaicingRight == true))
        {
            _patrollerEnemy.Flip();
        }

        _moverEnemy.MovePositionEnemy(nextPoint);
    }

    private bool GetStatusDirectionEnemy(float firstValueDistance, float secondValueDistance, bool isFaicingRight)
    {
        return firstValueDistance > secondValueDistance && isFaicingRight;
    }
}
