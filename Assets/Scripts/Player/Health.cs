using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<float, float> OnHealthChange;
    public UnityEvent<float, float> OnHealthSetup;
    public UnityEvent OnHealthDepleted;
    public UnityEvent OnHealthFilled;

    [SerializeField] float max = 100;
    [SerializeField] float min = 0;
    [SerializeField] float delta = 0;

    float previousValue;
    float value;

    private void Start()
    { 
        value = max;
        OnHealthSetup?.Invoke(min, max);
    }

    private void Update()
    {
        value += delta * Time.deltaTime;

        if (value <= min)
        {
            value = min;
            OnHealthDepleted?.Invoke();
        }
        else if (value >= max)
        {
            value = max;
            OnHealthFilled?.Invoke();
        }

        if (value != previousValue)
        {
            OnHealthChange?.Invoke(value, previousValue);
        }

        previousValue = value;
    }

    public void AdjustHealth(float change)
    { value += change; }
}