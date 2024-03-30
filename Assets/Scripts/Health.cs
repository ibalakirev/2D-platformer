using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthCharacter => _health;

    public void ReduceHealth(float damage)
    {
        _health -= damage;

        LimitHealth();

        Die();
    }

    public void IncreaseHealth(float healthMedkit)
    {
        _health += healthMedkit;

        LimitHealth();
    }

    private void Die()
    {
        float minValueHealth = 0f;

        if (_health <= minValueHealth)
        {
            gameObject.SetActive(false);
        }
    }

    private void LimitHealth()
    {
        float minValueHealth = 0f;
        float maxValueHealth = 100f;

        _health = Mathf.Clamp(_health, minValueHealth, maxValueHealth);
    }
}

