using System.Collections;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private float _damage;
    private Coroutine _coroutine;

    private void Start()
    {
        float minDamage = 5f;
        float maxDamage = 10f;

        _damage = Random.Range(minDamage, maxDamage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health player))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(WaitAttack(player));
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health player))
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator WaitAttack(Health player)
    {
        float delay = 2f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            player.ReduceCurrentValue(_damage);

            yield return wait;
        }
    }
}
