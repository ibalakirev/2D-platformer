using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _health;
    [SerializeField] PlayerSoundTakeDamagePlayer _soundTakeDamagePlayer;

    private void Update()
    {
        SlayPlayer();
    }

    public void IncreaseHealth(float healthMedkit)
    {
        _health += healthMedkit;
    }

    public void ReduceHealth(float damage)
    {
        _soundTakeDamagePlayer.PlaySoundTakeDamage();

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
