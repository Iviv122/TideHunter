using UnityEngine;
using Modules;
using VContainer;
using Base;

namespace Events
{
    public class PowerSwitch : Event
    {
        [SerializeField] Module module;
        private Building building;
        [SerializeField] bool StartState;
        [SerializeField] Event[] passModuleEvent;
        private void Awake()
        {
            module.OnStateChange += PassEvent; 
            Act(StartState);
        }
        private void PassEvent(bool state) {
            foreach (var item in passModuleEvent)
            {
                item.Act(state);
            }
        }
        [Inject]
        public void Construct(Building building)
        {
            this.building = building;
        }
        public override void Act()
        {
            module.SwitchState(building);
        }
        public override void Act(float value)
        {
        }
        public override void Act(bool state)
        {
            PassEvent(state);
            if (state)
            {
                module.TurnOn(building);
            }
            else
            {
                module.TurnOff(building);
            }
        }
    }
}