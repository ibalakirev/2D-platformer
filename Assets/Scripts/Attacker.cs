using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;

    private float _damage;

    public float Damage => _damage;

    private void Start()
    {
        _damage = Random.Range(minDamage, maxDamage);
    }
}
