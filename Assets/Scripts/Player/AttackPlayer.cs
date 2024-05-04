using UnityEngine;

public class AttackPlayer : Attacker
{
    private const string AttackWeapon = nameof(AttackWeapon);

    [SerializeField] private InputReader _inputer;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationEvents _eventsAttackAnimation;
    [SerializeField] private SoundPlayerAttack _soundAttack;
    

    private bool _isAttack;

    private void Update()
    {
        if (_inputer.GetInputAttack() == true)
        {
            _animator.SetTrigger(AttackWeapon);

            _soundAttack.PlaySoundAttack();

            _isAttack = true;
        }
    }

    private void OnEnable()
    {
        _eventsAttackAnimation.AttackAnimationFinished += FinishAttack;
    }

    private void OnDisable()
    {
        _eventsAttackAnimation.AttackAnimationFinished -= FinishAttack;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health enemyHealth) && _isAttack == true)
        {
            enemyHealth.ReduceCurrentValue(Damage);
        }
    }

    private void FinishAttack()
    {
        _isAttack = false;
    }
}

