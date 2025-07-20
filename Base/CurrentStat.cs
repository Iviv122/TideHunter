using System;
using UnityEngine;

namespace Base
{
    public class CurrentStatValue
    {
        float currentValue;
        public float timeModifier = 0.2f;
        public event Action OnChange;
        public event Action OnPowerOff;
        public CurrentStatValue(float StartValue, float timeMod)
        {
            currentValue = StartValue;
            timeModifier = timeMod;
        }
        public float CurrentValue
        {
            get
            {
                return currentValue;
            }
        }
        public void Tick(float deltaTime, float targetValue)
        {
            float delta = targetValue - currentValue;
            if (Mathf.Abs(delta) > 0)
            {
                float m = delta / Mathf.Abs(delta); // in theoty gives -1, 0 or 1
                currentValue += m * deltaTime * timeModifier;
                if (currentValue <= 0)
                {
                    OnPowerOff?.Invoke();
                }
                OnChange?.Invoke();
            }

        }
    }
}