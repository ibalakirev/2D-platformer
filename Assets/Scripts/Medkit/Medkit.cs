using UnityEngine;

public class Medkit : Prefab
{
    private float _healthEffect = 20f;

    public float HealthEffect => _healthEffect;

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void AcceptSound(AudioSource sound)
    {
        base.AcceptSound(sound);
    }
}
