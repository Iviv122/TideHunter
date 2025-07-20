using System;
using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules
{
    [CreateAssetMenu(fileName = "Radar", menuName = "Building/Modules/Radar", order = 0)]
    public class Radar : Module
    {
        StatModifier mod;
        StatModifier mod1;
        [SerializeField] float Energy = -500;
        [SerializeField] float Heat = 30;
        [SerializeField] float Battery = 20;
        [SerializeField] float InitialBattery = 20;
        [SerializeField] public float BatteryPercent { get; private set; }
        [SerializeField] public bool Started = false;
        public event Action OnLose;
        public event Action OnStart;
        public event Action OnChange;
        public override void Start()
        {

            Started = false;
            Battery = InitialBattery;
            Debug.Log("Battery restarted");
        }
        public void Lose()
        {
            OnLose?.Invoke();
            //Debug.Log("LoSER");
        }
        public override void Tick(float deltaTime)
        {
            if (!Started)
            {
                return;
            }
            if (Battery <= 0)
            {
                // lose
                Lose();
                Debug.Log("Losing");
                return;
            }
            if (mod != null)
            {
                Battery = Mathf.Min(InitialBattery, Battery + Time.deltaTime);
                BatteryPercent = Battery / InitialBattery;
                OnChange?.Invoke();
            }
            else
            {
                Battery -= Time.deltaTime;
                BatteryPercent = Battery / InitialBattery;
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
        }
        public override void TurnOff(Building building)
        {
            TurnOff();
        }

        public override void TurnOn(Building building)
        {
            mod = new StatModifier(StatType.Temperature, new AddOperation(Heat), 0);
            mod1 = new StatModifier(StatType.Energy, new AddOperation(Energy), 0);

            building.Stats.Mediator.AddModifier(mod);
            building.Stats.Mediator.AddModifier(mod1);
            StateChange(true);

            if (!Started)
            {
                OnStart?.Invoke();
            }
            Started = true;
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
            TurnOff(building);
        }
    }
}