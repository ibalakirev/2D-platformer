using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Medkit _medkit;
    private Coin _coin;

    public event Action MedkitFound;
    public event Action CoinFound;

    public Medkit Medkit => _medkit;
    public Coin Coin => _coin;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out _medkit))
        {
            MedkitFound?.Invoke();
        }

        if (other.gameObject.TryGetComponent(out _coin))
        {
            CoinFound?.Invoke();
        }
    }
}
