using System;
using Base;
using UnityEngine;
namespace Modules
{
    [CreateAssetMenu(fileName = "Battery", menuName = "Building/Modules/Battery", order = 0)]
    public class Battery : Module
    {
        StatModifier mod;
        [SerializeField] float Energy = 300;
        [SerializeField] float LifeTime = 300;
        [SerializeField] public float LifeTimePercent { get; private set; } // charge left
        [SerializeField] float InitialLifeTime = 300;
        public event Action OnChange;
        public override void Start()
        {
            LifeTime = InitialLifeTime;
        }
        public override void Tick(float deltaTime)
        {
            if (LifeTime <= 0)
            {
                TurnOff();
                return;
            }
            if (mod != null)
            {

                LifeTime -= Time.deltaTime;
                LifeTimePercent = LifeTime / InitialLifeTime;
                OnChange?.Invoke();
            }

        }
        public void TurnOff()
        {
            if (mod != null)
            {

                mod.MarkedForRemoval = true;
                mod = null;
            }
            StateChange(false);
        }
        public override void TurnOff(Building building)
        {
            TurnOff();
        }

        public override void TurnOn(Building building)
        {
            if (LifeTime <= 0)
            {
                TurnOff();
                return;
            }
            mod = new StatModifier(StatType.Energy, new AddOperation(Energy), 0);

            building.Stats.Mediator.AddModifier(mod);
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

        public override void BlackOut(Building building)
        {
        }
    }
}