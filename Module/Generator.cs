using System;
using Base;
using Items;
using UnityEngine;

namespace Modules
{
    [CreateAssetMenu(fileName = "Generator", menuName = "Building/Modules/Generator", order = 0)]
    public class Generator : Module, IConsume
    {
        StatModifier mod = null;
        StatModifier mod1 = null;
        [SerializeField] float Energy = 600;
        [SerializeField] float Heat = 15;
        // in seconds
        [SerializeField] float Fuel = 150;
        [SerializeField] public float FuelPercent { get; private set; }
        [SerializeField] float MaxFuel = 150;
        [SerializeField] float FuelPerCanister = 50;
        public event Action OnChange;
        public override void Start()
        {
            Fuel = MaxFuel;
            mod = null;
            mod1 = null;
        }
        public override void Tick(float deltaTime)
        {
            if (Fuel <= 0)
            {
                TurnOff();
                return;
            }
            if (mod != null)
            {
                Fuel -= Time.deltaTime;
                FuelPercent = Fuel / MaxFuel;
                OnChange?.Invoke();
            }
        }
        public void TurnOff()
        {
            if (mod != null)
            {
                mod.MarkedForRemoval = true;
                mod1.MarkedForRemoval = true;

            }

            mod = null;
            mod1 = null;
            StateChange(false);
        }
        public override void TurnOff(Building building)
        {
            TurnOff();
        }

        public override void TurnOn(Building building)
        {
            if (Fuel <= 0)
            {
                TurnOff();
                return;
            }
            mod = new StatModifier(StatType.Temperature, new AddOperation(Heat), 0);
            mod1 = new StatModifier(StatType.Energy, new AddOperation(Energy), 0);

            building.Stats.Mediator.AddModifier(mod);
            building.Stats.Mediator.AddModifier(mod1);
            StateChange(true);
        }
        public override void SwitchState(Building building)
        {
            if (mod == null)
            {
                TurnOn(building);
            }
            else
            {
                TurnOff(building);
            }
        }
        public void OnConsume()
        {
            Fuel += FuelPerCanister;
            if (Fuel > MaxFuel) {
                Fuel = MaxFuel;
            }
        }
    }
}