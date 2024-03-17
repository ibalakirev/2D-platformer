using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private DisablerCoin _prefabCoin;

    private void Start()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        int indexPoints = 0;

        for (int i = indexPoints; i < _spawnPoints.Count; i++)
        {
            Instantiate(_prefabCoin, _spawnPoints[i]);
        }
    }
}
