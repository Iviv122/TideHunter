using System;

namespace Base
{
    public class BuildingStats
    {
        public readonly StatsMediator Mediator;
        public event Action OnStatChange;
        private float temperature = 30;
        private float powerSuply = 0;
        public BuildingStats(float baseTemperature = 30,float basePowerSupply = 30)
        {
            Mediator = new();
            Mediator.OnModifierAdd += StatChange;
            Mediator.OnModifierRemove += StatChange;
            temperature = baseTemperature;
            powerSuply = basePowerSupply;
        }
        void StatChange()
        {
            OnStatChange?.Invoke();
        }
        public float PowerSuply
        {
            get
            {
                Querry q = new Querry(StatType.Energy, powerSuply);
                Mediator.PerformQuerry(q);
                return q.Value;
            }
        }
        public float Temperature
        {
            get
            {
                Querry q = new Querry(StatType.Temperature, temperature);
                Mediator.PerformQuerry(q);
                return q.Value;
            }
        }
        public void Tick(float deltaTime)
        {
            Mediator.Tick(deltaTime);
        }
    }
}