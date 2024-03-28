using UnityEngine;

public class Coin : Prefab
{
    public override void Destroy()
    {
        base.Destroy();
    }

    public override void AcceptSound(AudioSource sound)
    {
        base.AcceptSound(sound);
    }
}
