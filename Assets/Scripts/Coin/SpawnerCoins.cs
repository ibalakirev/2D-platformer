using UnityEngine;

public class SpawnerCoins : Spawner
{
    [SerializeField] private Coin _coin;

    public override void CreatePrefab(int index)
    {
        Coin coin = Instantiate(_coin, SpawnPoints[index]);

        coin.SetSound(Sound);
    }
}
