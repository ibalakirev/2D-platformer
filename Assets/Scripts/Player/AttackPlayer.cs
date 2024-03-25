using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private const string AttackWeapon = nameof(AttackWeapon);

    [SerializeField] private Animator _animator;
    [SerializeField] private Inputer _inputer;
    [SerializeField] PlayerSoundAttackPlayer _sundAttack;

    private float _damage;
    [SerializeField] private bool _isAttack = false;

    private void Start()
    {
        float minDamage = 20f;
        float maxDamage = 50f;

        _damage = Random.Range(minDamage, maxDamage);
    }

    private void Update()
    {
        if (_inputer.GetAttack() == true)
        {
            _animator.SetTrigger(AttackWeapon);

            _sundAttack.PlaySoundAttack();

            _isAttack = true;
        }
    }

    public void FinishAttack()
    {
        _isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthEnemy healthEnemy = other.GetComponent<HealthEnemy>();

        if (healthEnemy != null && _isAttack == true)
        {
            healthEnemy.ReduceHealth(_damage);
        }
    }
}

