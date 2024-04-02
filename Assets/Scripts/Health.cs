using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthCharacter => _health;

    public void ReduceHealth(float damage)
    {
        if (IsAlive() == true)
        {
            _health -= damage;

            LimitHealth();

            TryDie();
        }
    }

    public void IncreaseHealth(float healthMedkit)
    {
        if (IsAlive() == true)
        {
            _health += healthMedkit;

            LimitHealth();
        }
    }

    private void TryDie()
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

    private bool IsAlive()
    {
        float minValueHealth = 0f;

        if (_health > minValueHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

