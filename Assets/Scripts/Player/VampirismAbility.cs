using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class VampirismAbility : PlayerSkills
{
    [SerializeField] private LayerMask _enemiesLayer;
    [SerializeField] private float _skillRadius = 5f;
    [SerializeField] private float _skillDamage = 30f;
    [SerializeField] private int _duractionSkill = 6;

    private int _currentValueCooldown;
    private float _currentSkillDamage;
    private Health _health;
    private Coroutine _coroutineCooldown;
    private Coroutine _coroutineStealHealth;

    public event Action CooldownIterated;
    public event Action CooldownDisabled;
    public event Action StealHealthIterated;
    public event Action StealHealthDisabled;

    public int CurrentValueCooldown => _currentValueCooldown;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _skillRadius);
    }

    protected override bool GetInputUseSkill()
    {
        return InputReader.GetInputVampirismSkill();
    }

    protected override void UseSkill()
    {
        if (_coroutineCooldown == null && _coroutineStealHealth == null)
        {
            _coroutineStealHealth = StartCoroutine(StealHealth());
        }
    }

    private IEnumerator StealHealth()
    {
        float delay = 1f;
        float distanceEnemy;
        float maxDistance = 100f;
        Collider2D enemy = new Collider2D();

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        for (int i = 0; i < _duractionSkill; i++)
        {
            StealHealthIterated?.Invoke();

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _skillRadius, _enemiesLayer);

            if (enemies.Length > 0)
            {
                for (int j = 0; j < enemies.Length; j++)
                {
                    distanceEnemy = Vector2.Distance(transform.position, enemies[j].transform.position);

                    if (distanceEnemy < maxDistance)
                    {
                        maxDistance = distanceEnemy;

                        enemy = enemies[j];
                    }
                }

                StealHealthNearestEnemy(enemy);
            }

            yield return timeWait;
        }

        _coroutineCooldown = StartCoroutine(Cooldown());

        StopCurrentCorourine(ref _coroutineStealHealth);

        StealHealthDisabled?.Invoke();
    }

    private IEnumerator Cooldown()
    {
        float delay = 1f;
        int timeCooldown = 5;

        ResetCooldown(timeCooldown);

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        for (int i = 0; i < timeCooldown; i++)
        {
            --_currentValueCooldown;

            CooldownIterated?.Invoke();

            yield return timeWait;
        }

        StopCurrentCorourine(ref _coroutineCooldown);

        ResetCooldown(timeCooldown);

        CooldownDisabled?.Invoke();
    }

    private void StealHealthNearestEnemy(Collider2D enemy)
    {
        ResetCurrentSkillDamage();

        if (enemy.TryGetComponent<Health>(out var enemyHealth))
        {
            if (enemyHealth.CurrentValue < _skillDamage)
            {
                _currentSkillDamage = enemyHealth.CurrentValue;
            }

            enemyHealth.ReduceCurrentValue(_currentSkillDamage);

            _health.IncreaseCurrentValue(_currentSkillDamage);

            ResetCurrentSkillDamage();
        }
    }

    private void ResetCurrentSkillDamage()
    {
        _currentSkillDamage = _skillDamage;
    }

    private void ResetCooldown(int maxValueCooldown)
    {
        _currentValueCooldown = maxValueCooldown;
    }

    private void StopCurrentCorourine(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);

            coroutine = null;
        }
    }
}
