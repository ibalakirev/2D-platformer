using System.Collections;
using UnityEngine;

public class AttackEnemy : Attacker
{
    private Coroutine _coroutine;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health healthPlayer))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(WaitAttack(healthPlayer));
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health healthPlayer))
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator WaitAttack(Health healthPlayer)
    {
        float delay = 2f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (gameObject.activeSelf)
        {
            healthPlayer.ReduceCurrentValue(Damage);

            yield return timeWait;
        }
    }
}
