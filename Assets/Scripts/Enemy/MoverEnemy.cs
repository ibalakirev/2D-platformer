using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyVision), typeof(PatrollerEnemy))]
[RequireComponent(typeof(PatrollerEnemy))]

public class MoverEnemy : MonoBehaviour
{
    private PatrollerEnemy _patrollerEnemy;
    private EnemyVision _enemyVision;
    private StalkerEnemy _stalkerEnemy;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyVision = GetComponent<EnemyVision>();
        _stalkerEnemy = GetComponent<StalkerEnemy>();
        _patrollerEnemy = GetComponent<PatrollerEnemy>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void MovePositionEnemy(Vector2 nextPoint)
    {
        _rigidbody.MovePosition((Vector2)transform.position + nextPoint);
    }

    private void Move()
    {
        Vector2 nextPoint = Vector2.right * _patrollerEnemy.SpeedPatrolEnemy * Time.fixedDeltaTime;

        if (_enemyVision.IsPlayerSaw == true)
        {
            _patrollerEnemy.GetRestartWaitTimePatrol();

            _stalkerEnemy.ChasePlayer(nextPoint, _patrollerEnemy.IsFaicingRight);
        }

        if (_enemyVision.IsPlayerSaw == false && _patrollerEnemy.WaitTimePatrol == _patrollerEnemy.TimeToWaitPatrol)
        {
            _patrollerEnemy.Patrol(nextPoint, _patrollerEnemy.IsFaicingRight);
        }
    }
}
