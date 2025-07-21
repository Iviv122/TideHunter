using Modules;
using UnityEngine;
using VContainer.Unity;

namespace Base
{
    public class Building : ITickable
    {
        public readonly BuildingStats Stats;
        public readonly CurrentStatValue Heat;
        public readonly CurrentStatValue Power;
        public readonly ModuleManager ModuleManager;
        public Building(ModuleManager moduleManager)
        {
            Stats = new(30, 150);
            Heat = new(Stats.Temperature, 0.2f);
            Power = new(Stats.PowerSuply, 10f);
            ModuleManager = moduleManager;

            Power.OnPowerOff += PowerOff;
        }

        private void PowerOff()
        {
            ModuleManager.PowerOff(this);
        } 

        void ITickable.Tick()
        {
            Stats.Tick(Time.deltaTime);
            Heat.Tick(Time.deltaTime, Stats.Temperature);
            Power.Tick(Time.deltaTime, Stats.PowerSuply);
        }
    }

}