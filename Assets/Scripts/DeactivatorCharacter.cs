using UnityEngine;

public class DeactivatorCharacter : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.DeathReported += Slay;
    }

    private void OnDisable()
    {
        _health.DeathReported -= Slay;
    }

    private void Slay()
    {
        gameObject.SetActive(false);
    }
}
