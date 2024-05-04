public class SoundCoin : SoundsItems
{
    private void OnEnable()
    {
        CollisionHandler.CoinFound += PlaySound;
    }

    private void OnDisable()
    {
        CollisionHandler.CoinFound -= PlaySound;
    }
}
