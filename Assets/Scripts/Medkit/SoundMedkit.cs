public class SoundMedkit : SoundsItems
{
    private void OnEnable()
    {
        CollisionHandler.MedkitFound += PlaySound;
    }

    private void OnDisable()
    {
        CollisionHandler.MedkitFound -= PlaySound;
    }
}
