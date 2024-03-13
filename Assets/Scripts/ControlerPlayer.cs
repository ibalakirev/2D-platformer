using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ControlerPlayer : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Ground = nameof(Ground);
    private const string SpeedX = nameof(SpeedX);

    [SerializeField] private float _speedWalk;
    [SerializeField] private float _powerJump;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _soundJump;

    private float _multiplySpeedWalk = 50f;
    private float _multiplyJump = 100f;
    private float _horizontal = 0;
    private bool _isFaicingRight = true;
    private bool _isJump = false;
    private bool _isGround = false;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float valueGetAxis = 0;

        Move();

        if (GetConditionsForFlip(_horizontal, valueGetAxis, _isFaicingRight == false))
        {
            Flip();
        }
        else if (GetConditionsForFlip(valueGetAxis, _horizontal, _isFaicingRight == true))
        {
            Flip();
        }

        if (_isJump == true)
        {
            Jump();

            _isGround = false;
            _isJump = false;
        }
    }

    private bool GetConditionsForFlip(float firstValue, float secondValue, bool _isFaicingRight)
    {

        return firstValue > secondValue && _isFaicingRight;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis(Horizontal);

        _animator.SetFloat(SpeedX, Mathf.Abs(_horizontal));

        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            _isJump = true;
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_horizontal * _speedWalk * _multiplySpeedWalk * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    private void Flip()
    {
        int multiplierPlayerScale = -1;
        Vector3 playerScale = transform.localScale;

        _isFaicingRight = !_isFaicingRight;

        playerScale.x *= multiplierPlayerScale;
        transform.localScale = playerScale;
    }

    private void Jump()
    {
        float powerVectorX = 0;

        _rigidbody.AddForce(new Vector2(powerVectorX, _powerJump * _multiplyJump * Time.fixedDeltaTime));

        _soundJump.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Ground))
        {
            _isGround = true;
        }
    }
}
