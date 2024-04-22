
public class HealthBarEnemy : IndicatorHealth
{
    private void OnEnable()
    {
        Character.CurrentValueReduce += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        Character.CurrentValueReduce -= ChangeValueIndicator;
    }
}
