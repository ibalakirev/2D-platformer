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

    public void MovePositionEnemy(Vector2 offset)
    {
        _rigidbody.MovePosition((Vector2)transform.position + offset);
    }

    private void Move()
    {
        Vector2 offset = Vector2.right * _patrollerEnemy.SpeedPatrolEnemy * Time.fixedDeltaTime;

        if (_enemyVision.IsSaw == true)
        {
            _stalkerEnemy.ChasePlayer(offset);
        }

        if (_enemyVision.IsSaw == false)
        {
            _patrollerEnemy.Patrol(offset);
        }
    }
}
