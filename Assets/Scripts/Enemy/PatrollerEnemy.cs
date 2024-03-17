using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PatrollerEnemy : MonoBehaviour
{
    [SerializeField] private float _timeToWait = 3f;
    [SerializeField] private float _speedPatrolEnemy = 3f;
    [SerializeField] private Transform _leftPointPosition;
    [SerializeField] private Transform _rightPointPosition;

    private bool _isFaicingRight = true;
    private float _waitTime;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(WaitChangeDirection(_timeToWait));

        _waitTime = _timeToWait;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float multiplySpeedEnemy = -1;

        Vector2 nextPoint = Vector2.right * _speedPatrolEnemy * Time.fixedDeltaTime;

        if (_isFaicingRight == false)
        {
            nextPoint.x *= multiplySpeedEnemy;
        }

        if (_waitTime == _timeToWait)
        {
            _rigidbody.MovePosition((Vector2)transform.position + nextPoint);
        }
    }

    private IEnumerator WaitChangeDirection(float delay, int minTime = 0, int maxTime = 3)
    {
        bool isWorkCoroutine = true;
        float valueWaitTimeSubtraction = 1;

        WaitForSeconds wait = new WaitForSeconds(1f);

        while (isWorkCoroutine)
        {
            if (GetPositionPointFinishDistance() == true && _waitTime > minTime)
            {
                for (int i = maxTime; i > minTime; i--)
                {
                    _waitTime -= valueWaitTimeSubtraction;

                    yield return wait;
                }
            }

            if (_waitTime <= minTime)
            {
                _waitTime = _timeToWait;

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

    private void Flip()
    {
        float degreesRotationAxisX = 0f;
        float degreesRotationAxisY = 180f;
        float degreesRotationAxisZ = 0f;

        _isFaicingRight = !_isFaicingRight;

        transform.Rotate(degreesRotationAxisX, degreesRotationAxisY, degreesRotationAxisZ);
    }
}
