using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Inputer))]

public class MoverPlayer : MonoBehaviour
{
    private const string Ground = nameof(Ground);
    private const string SpeedX = nameof(SpeedX);

    [SerializeField] private float _speedWalk;
    [SerializeField] private float _powerJump;
    [SerializeField] private Animator _animator;
    [SerializeField] Transform _playerModel;

    private float _multiplySpeedWalk = 50f;
    private float _multiplyJump = 100f;
    private bool _isFaicingRight = true;
    private bool _isGround = false;
    private bool _isJump = false;

    private Inputer _inputer;
    private Rigidbody2D _rigidbody;

    public event Action SoundJumpStarted;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputer = GetComponent<Inputer>();
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
        Jump();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedX, Mathf.Abs(_inputer.HorizontalAxis));

        if (_inputer.GetInputJump() == true && _isGround == true)
        {
            _isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Ground))
        {
            _isGround = true;
        }
    }

    private void Jump()
    {
        float powerVectorX = 0;

        if (_isJump == true)
        {
            SoundJumpStarted.Invoke();

            _rigidbody.AddForce(new Vector2(powerVectorX, _powerJump * _multiplyJump * Time.fixedDeltaTime));

            _isGround = false;
            _isJump = false;
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_inputer.HorizontalAxis * _speedWalk * _multiplySpeedWalk * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    private void Flip()
    {
        float directionAxis = 0;

        if (GetConditionsForFlip(_inputer.HorizontalAxis, directionAxis, _isFaicingRight == false) ||
            GetConditionsForFlip(directionAxis, _inputer.HorizontalAxis, _isFaicingRight == true))
        {
            RotatePlayer();
        }
    }

    private bool GetConditionsForFlip(float firstDirectionAxis, float secondDirectionAxis, bool _isFaicingRight)
    {
        return firstDirectionAxis > secondDirectionAxis && _isFaicingRight;
    }

    private void RotatePlayer()
    {
        float degreesRotationAxisX = 0f;
        float degreesRotationAxisY = 180f;
        float degreesRotationAxisZ = 0f;

        _isFaicingRight = !_isFaicingRight;

        _playerModel.Rotate(degreesRotationAxisX, degreesRotationAxisY, degreesRotationAxisZ);
    }
}
