using Base;
using UnityEngine;

namespace Modules
{
    [CreateAssetMenu(fileName = "Cooler", menuName = "Building/Modules/Coolder", order = 0)]
    public class Cooler : Module
    {
        StatModifier mod;
        StatModifier mod1;
        [SerializeField] float Energy = -300;
        [SerializeField] float Heat = -30;

        public override void TurnOff(Building building)
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

        public override void TurnOn(Building building)
        {
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

        public override void BlackOut(Building building)
        {
            TurnOff(building);
        }
    }
}