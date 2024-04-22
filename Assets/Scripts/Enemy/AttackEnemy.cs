using System.Collections;
using UnityEngine;

public class AttackEnemy : Attacker
{
    private Coroutine _coroutine;

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

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (gameObject.activeSelf)
        {
            player.ReduceCurrentValue(Damage);

            yield return timeWait;
        }
    }
}
