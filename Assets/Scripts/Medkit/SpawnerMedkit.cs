using UnityEngine;

 public class SpawnerMedkit : Spawner
{
    [SerializeField] private Medkit _medkit;

    private void Start()
    {
        CreatePrefabs();
    }

    public override void CreatePrefab(int index)
    {
        Medkit medkit = Instantiate(_medkit, SpawnPoints[index]);

        medkit.AcceptSound(Sound);
    }
}
