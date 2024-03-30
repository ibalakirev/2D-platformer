using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoverEnemy), typeof(EnemyVision))]

public class PatrollerEnemy : MonoBehaviour
{
    [SerializeField] private float _timeToWaitPatrol = 3f;
    [SerializeField] private float _speedPatrolEnemy;
    [SerializeField] private Transform _leftPointPosition;
    [SerializeField] private Transform _rightPointPosition;

    private MoverEnemy _moverEnemy;
    private EnemyVision _enemyVision;
    private float _waitTimePatrol;
    private bool _isFaicingRight = true;

    public float SpeedPatrolEnemy => _speedPatrolEnemy;
    public bool IsFaicingRight => _isFaicingRight;
    public float TimeToWaitPatrol => _timeToWaitPatrol;
    public float WaitTimePatrol => _waitTimePatrol;

    private void Start()
    {
        _moverEnemy = GetComponent<MoverEnemy>();

        _enemyVision = GetComponent<EnemyVision>(); 

        StartCoroutine(WaitChangeDirection());

        GetRestartWaitTimePatrol();
    }

    public void Patrol(Vector2 offset)
    {
        float multiplySpeedEnemy = -1;

        if (_isFaicingRight == false)
        {
            offset.x *= multiplySpeedEnemy;
        }

        _moverEnemy.MovePositionEnemy(offset);
    }

    public void GetRestartWaitTimePatrol()
    {
        _waitTimePatrol = _timeToWaitPatrol;
    }

    public void Flip()
    {
        float degreesRotationAxisX = 0f;
        float degreesRotationAxisY = 180f;
        float degreesRotationAxisZ = 0f;

        _isFaicingRight = !_isFaicingRight;

        transform.Rotate(degreesRotationAxisX, degreesRotationAxisY, degreesRotationAxisZ);
    }

    private IEnumerator WaitChangeDirection(float delay = 1f, int minTime = 0, int maxTime = 3)
    {
        bool isWorkCoroutine = true;
        float valueWaitTimeSubtraction = 1;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (isWorkCoroutine)
        {
            if (GetPositionPointFinishDistance() == true && _waitTimePatrol > minTime && _enemyVision.IsPlayerSaw == false)
            {
                for (int i = maxTime; i > minTime; i--)
                {
                    _waitTimePatrol -= valueWaitTimeSubtraction;

                    yield return wait;
                }
            }

            if (_waitTimePatrol <= minTime)
            {
                GetRestartWaitTimePatrol();

                Flip();
            }

            yield return null;
        }
    }

    private bool GetPositionPointFinishDistance()
    {
        bool isOutRightPoint = _isFaicingRight == true && transform.position.x >= _rightPointPosition.transform.position.x;
        bool isOutLeftPoint = _isFaicingRight == false && transform.position.x <= _leftPointPosition.transform.position.x;

        return isOutRightPoint || isOutLeftPoint;
    }
}
