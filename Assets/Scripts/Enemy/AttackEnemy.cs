using System.Collections;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private float _damage;
    private Coroutine _coroutine;

    private void Start()
    {
        float minDamage = 20f;
        float maxDamage = 50f;

        _damage = Random.Range(minDamage, maxDamage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HealthPlayer healthPlayer = other.gameObject.GetComponent<HealthPlayer>();

        if (healthPlayer == true)
        {
            _coroutine = StartCoroutine(WaitAttack(healthPlayer));
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        HealthPlayer healthPlayer = other.gameObject.GetComponent<HealthPlayer>();

        if (healthPlayer == true)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator WaitAttack(HealthPlayer healthPlayer)
    {
        bool isWorkCoroutine = true;
        float delay = 2f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (isWorkCoroutine)
        {
            healthPlayer.ReduceHealth(_damage);

            yield return wait;
        }
    }
}
