using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;

    private float _damage;
    private Health _character;

    public Health Character => _character;

    public float Damage => _damage;

    private void Start()
    {
        _damage = Random.Range(minDamage, maxDamage);
    }
}
