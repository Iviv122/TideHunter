using UnityEngine;
using VContainer;
using Base;
using Items;

namespace Events
{
    public class ItemConsumer : Event
    {
        [SerializeField] float PowerPerItem;
        [SerializeField] float effectDuration;
        [SerializeField] Event passEvent;
        private Building building;
        private Hand hand;
        [Inject]
        public void Construct(Hand hand, Building building)
        {
            this.hand = hand;
            this.building = building;
        }
        public override void Act()
        {
            if (!hand.isEmpty())
            {
                Debug.Log("Trying to use");
                hand.ConsumeItem();
                StatModifier mod = new StatModifier(StatType.Energy, new AddOperation(PowerPerItem), effectDuration);
                building.Stats.Mediator.AddModifier(mod);
                passEvent.Act();
            }
        }
        public override void Act(float value)
        {
        }
        public override void Act(bool state)
        {
        }
    }
}