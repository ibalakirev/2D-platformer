using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _health;  

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

        return true;
    }
}

