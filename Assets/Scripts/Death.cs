using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.DeathReport += Slay;
    }

    private void OnDisable()
    {
        _health.DeathReport -= Slay;
    }

    private void Slay()
    {
        gameObject.SetActive(false);
    }
}
