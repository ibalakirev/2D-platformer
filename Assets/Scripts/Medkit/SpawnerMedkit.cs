using UnityEngine;

 public class SpawnerMedkit : Spawner
{
    [SerializeField] private Medkit _medkit;

    public override void CreatePrefab(int index)
    {
        Medkit medkit = Instantiate(_medkit, SpawnPoints[index]);

        medkit.SetSound(Sound);
    }
}
