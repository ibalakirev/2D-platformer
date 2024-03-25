using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField, Range(1f, 100f)] private float _health;

    private void Update()
    {
        SlayPlayer();
    }

    public void ReduceHealth (float damage)
    {
        _health -= damage;
    }

    private void SlayPlayer()
    {
        float minValueHealth = 0f;

        if (_health <= minValueHealth)
        {
            gameObject.SetActive(false);
        }
    }
}

