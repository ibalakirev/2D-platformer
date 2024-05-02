using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class VampirismSkill : PlayerSkills
{
    [SerializeField] private float _skillRadius;
    [SerializeField] private LayerMask _enemiesLayer;
    [SerializeField] private float _vampirism = 20f;

    private Health _health;  
    private Coroutine _coroutine;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _skillRadius);
    }

    protected override bool SetInput()
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
        int duration = 6;
        int minValue = 0;
        float delay = 1f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        for (int i = minValue; i < duration; i++)
        {
            float vampirismValue = _vampirism;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _skillRadius, _enemiesLayer);
            Dictionary<Collider2D, float> distanceEnemies = new Dictionary<Collider2D, float>();
            List<float> distance = new List<float>();

            for (int j = minValue; j < enemies.Length; j++)
            {
                distance.Add(Vector2.Distance(transform.position, enemies[j].transform.position));
                distanceEnemies.Add(enemies[j], distance[j]);
            }

            if (distance.Count > minValue)
            {
                float minDistance = distance.Min();
                var targetEnemies = distanceEnemies.Where(enemy => enemy.Value == minDistance);

                foreach (var enemy in targetEnemies)
                {
                    if (enemy.Key.GetComponent<Health>().CurrentValue > minValue)
                    {
                        enemy.Key.GetComponent<Health>().ReduceCurrentValue(_vampirism);

                        _health.IncreaseCurrentValue(_vampirism);
                    }
                }
            }

            yield return timeWait;
        }
    }
}
