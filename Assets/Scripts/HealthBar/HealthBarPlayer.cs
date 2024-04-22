
public class HealthBarPlayer : IndicatorHealth
{
    private void OnEnable()
    {
        Character.CurrentValueReduce += ChangeValueIndicator;
        Character.CurrentValueIncreas += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        Character.CurrentValueReduce -= ChangeValueIndicator;
        Character.CurrentValueIncreas -= ChangeValueIndicator;
    }
}
