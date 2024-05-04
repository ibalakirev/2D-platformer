using UnityEngine;

public class ItemsHandler : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _collisionHandler.MedkitFound += UseMedkit;
        _collisionHandler.CoinFound += UseCoin;
    }

    private void OnDisable()
    {
        _collisionHandler.MedkitFound -= UseMedkit;
        _collisionHandler.CoinFound -= UseCoin;
    }

    private void UseMedkit()
    {
        _health.IncreaseCurrentValue(_collisionHandler.Medkit.HealthEffect);

        DisableItem(_collisionHandler.Medkit.gameObject);
    }

    private void UseCoin()
    {
        DisableItem(_collisionHandler.Coin.gameObject);
    }

    private void DisableItem(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
