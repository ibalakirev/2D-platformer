using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private const string AttackWeapon = nameof(AttackWeapon);

    [SerializeField] private Animator _animator;
    [SerializeField] private Inputer _inputer;
    [SerializeField] SoundPlayerAttack _soundAttack;

    private float _damage;
    private bool _isAttack;

    private void Start()
    {
        float minDamage = 20f;
        float maxDamage = 50f;

        _damage = Random.Range(minDamage, maxDamage);
    }

    private void Update()
    {
        if (_inputer.GetInputAttack() == true)
        {
            _animator.SetTrigger(AttackWeapon);

            _soundAttack.PlaySoundAttack();

            _isAttack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Health enemyHealth) && _isAttack == true)
        {
            enemyHealth.ReduceHealth(_damage);
        }
    }

    public void FinishAttack()
    {
        _isAttack = false;
    }
}

