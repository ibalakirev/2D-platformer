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
        if (other.gameObject.TryGetComponent(out Health player))
        {
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
        bool isWorkCoroutine = true;
        float delay = 2f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (isWorkCoroutine)
        {
            player.ReduceHealth(_damage);
            player.Die();

            yield return wait;
        }
    }
}
