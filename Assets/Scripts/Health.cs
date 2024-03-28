using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthCharacter => _health;

    public void ReduceHealth (float damage)
    {
        _health -= damage;
    }

    public void IncreaseHealth(float healthMedkit)
    {
        _health += healthMedkit;
    }

    public bool Die()
    {
        float minValueHealth = 0f;

        if (_health <= minValueHealth)
        {
            gameObject.SetActive(false);
        }

        LimitHealth();

        return true;
    }

    private void LimitHealth()
    {
        float minValueHealth = 0f;

        if(_health <= minValueHealth)
        {
            _health = 0f;
        }
    }
}

