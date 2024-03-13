using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ControlerEnemy : MonoBehaviour
{
    [SerializeField] private float _walkDistance = 6f;
    [SerializeField] private float _timeToWait = 3f;
    [SerializeField] private float _speedPatrolEnemy = 3f;

    private Vector2 _leftPointPosition;
    private Vector2 _rightPointPosition;
    private bool _isFaicingRight = true;
    private bool _isWait = false;
    private float _waitTime;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _waitTime = _timeToWait;

        _leftPointPosition = transform.position;
        _rightPointPosition = _leftPointPosition + Vector2.right * _walkDistance;
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

        if (_isWait == false)
        {
            _rigidbody.MovePosition((Vector2)transform.position + nextPoint);
        }
    }

    private void Update()
    {
        Wait();

        if (GetPositionPointFinishDistance())
        {
            _isWait = true;
        }
    }

    private void Wait()
    {
        float vlaueTime = 0f;

        if (_isWait == true)
        {
            _waitTime -= Time.deltaTime;

            if (_waitTime < vlaueTime)
            {
                _waitTime = _timeToWait;
                _isWait = false;

                Flip();
            }
        }
    }

    private bool GetPositionPointFinishDistance()
    {
        bool isOutRightPoint = _isFaicingRight == true && transform.position.x >= _rightPointPosition.x;
        bool isOutLeftPoint = _isFaicingRight == false && transform.position.x <= _leftPointPosition.x;

        return isOutRightPoint || isOutLeftPoint;
    }

    private void Flip()
    {
        float multiplyEnemyScale = -1;
        Vector3 enemyScale = transform.localScale;

        _isFaicingRight = !_isFaicingRight;

        enemyScale.x *= multiplyEnemyScale;
        transform.localScale = enemyScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftPointPosition, _rightPointPosition);
    }
}
