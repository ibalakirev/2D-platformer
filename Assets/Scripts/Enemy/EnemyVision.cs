using UnityEngine;

[RequireComponent(typeof(PatrollerEnemy))]

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private GameObject _currentHitObject;
    [SerializeField] private float _circleRadius;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;

    private PatrollerEnemy _patrollerEnemy;
    private Vector2 _originCirclePosition;
    private Vector2 _direction;
    private float _currentHitDistance;
    private bool _isPlayerSaw;

    public bool IsPlayerSaw => _isPlayerSaw;

    private void Start()
    {
        _patrollerEnemy = GetComponent<PatrollerEnemy>();
    }

    private void Update()
    {
        DefineStatusVisionEnemy();
    }

    private void DefineStatusVisionEnemy()
    {
        RaycastHit2D visionEnemy = GetVisionEnmy();

        DefineDirectionVisionEnemy();

        if (visionEnemy == true)
        {
            _currentHitObject = visionEnemy.transform.gameObject;
            _currentHitDistance = visionEnemy.distance;

            if (_currentHitObject.GetComponent<MovePlayer>())
            {
                _isPlayerSaw = true;
            }
        }
        else
        {
            _isPlayerSaw = false;
            _currentHitObject = null;
            _currentHitDistance = _maxDistance;
        }
    }

    private RaycastHit2D GetVisionEnmy()
    {
        _originCirclePosition = transform.position;

        RaycastHit2D hit = Physics2D.CircleCast(_originCirclePosition, _circleRadius, _direction, _maxDistance, _layerMask);

        return hit;
    }

    private void DefineDirectionVisionEnemy()
    {
        if (_patrollerEnemy.IsFaicingRight == true)
        {
            _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.left;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_originCirclePosition, _originCirclePosition + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_originCirclePosition + _direction * _currentHitDistance, _circleRadius);
    }

}
