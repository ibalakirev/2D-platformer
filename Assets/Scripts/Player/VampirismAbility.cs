using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class VampirismAbility : PlayerSkills
{
    [SerializeField] private LayerMask _enemiesLayer;
    [SerializeField] private GameObject _skillImage;
    [SerializeField] private float _skillRadius = 5f;
    [SerializeField] private float _skillDamage = 20f;
    [SerializeField] private int _duractionSkill = 6;

    private int _counterDurationSkill;
    private Health _health;
    private Coroutine _coroutine;

    public event Action SkillEnabled;
    public event Action SkillDisabled;

    public int CounterDurationSkill => _counterDurationSkill;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _skillRadius);
    }

    protected override bool SetInputUseSkill()
    {
        return InputReader.GetInputVampirismSkill();
    }

    protected override void UseSkill()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(StealHealth());
    }

    private IEnumerator StealHealth()
    {
        float delay = 1f;
        float vampirismDamageValue = _skillDamage;
        float distanceEnemy;

        ResetCounterTimeSkill();

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        for (int i = 0; i < _duractionSkill; i++)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _skillRadius, _enemiesLayer);
            Dictionary<Collider2D, float> distanceEnemies = new Dictionary<Collider2D, float>();

            SkillEnabled?.Invoke();

            --_counterDurationSkill;

            if (enemies.Length > 0)
            {
                for (int j = 0; j < enemies.Length; j++)
                {
                    distanceEnemy = Vector2.Distance(transform.position, enemies[j].transform.position);
                    distanceEnemies.Add(enemies[j], distanceEnemy);
                }

                float minDistance = distanceEnemies.Values.Min();
                var targetEnemies = distanceEnemies.Where(enemy => enemy.Value == minDistance);

                foreach (var enemy in targetEnemies)
                {
                    if (enemy.Key.TryGetComponent<Health>(out var enemyHealth))
                    {
                        if (enemyHealth.CurrentValue < _skillDamage)
                        {
                            vampirismDamageValue = enemyHealth.CurrentValue;
                        }

                        if (enemyHealth.CurrentValue > 0)
                        {
                            enemyHealth.ReduceCurrentValue(vampirismDamageValue);

                            _health.IncreaseCurrentValue(vampirismDamageValue);
                        }
                    }
                }

                vampirismDamageValue = _skillDamage;
            }

            yield return timeWait;
        }

        ResetCounterTimeSkill();

        SkillDisabled?.Invoke();
    }

    private void ResetCounterTimeSkill()
    {
        _counterDurationSkill = _duractionSkill;
    }
}
