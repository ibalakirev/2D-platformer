using UnityEngine;

[RequireComponent(typeof(MoverEnemy))]

public class PatrollerEnemy : MonoBehaviour
{
    [SerializeField] private float _speedPatrolEnemy;
    [SerializeField] private Transform[] _patrolPoints;

    private MoverEnemy _moverEnemy;
    private bool _isFaicingRight = true;

    public float SpeedPatrolEnemy => _speedPatrolEnemy;
    public bool IsFaicingRight => _isFaicingRight;

    private void Start()
    {
        _moverEnemy = GetComponent<MoverEnemy>();
    }

    public void Patrol(Vector2 offset)
    {
        float multiplySpeedEnemy = -1;

        if (_isFaicingRight == false)
        {
            offset.x *= multiplySpeedEnemy;
        }

        _moverEnemy.MovePositionEnemy(offset);

        if (GetPositionPointFinishDistance() == true)
        {
            Flip();
        }
    }

    public void Flip()
    {
        float degreesRotationAxisX = 0f;
        float degreesRotationAxisY = 180f;
        float degreesRotationAxisZ = 0f;

        _isFaicingRight = !_isFaicingRight;

        transform.Rotate(degreesRotationAxisX, degreesRotationAxisY, degreesRotationAxisZ);
    }

    private bool GetPositionPointFinishDistance()
    {
        Transform firstPointPatrol = _patrolPoints[0];
        Transform SecondPointPatrol = _patrolPoints[1];

        bool isOutRightPoint = _isFaicingRight == true && transform.position.x >= firstPointPatrol.transform.position.x;
        bool isOutLeftPoint = _isFaicingRight == false && transform.position.x <= SecondPointPatrol.transform.position.x;

        return isOutRightPoint || isOutLeftPoint;
    }
}