using UnityEngine;
using Modules;
using VContainer;
using AYellowpaper;
using Items;

namespace Events
{
    public class ConsumeItem : Event
    {
        [SerializeField] InterfaceReference<IConsume> module;
        [SerializeField] ItemType ItemToUse;
        [SerializeField] Event passEvent;
        private Hand hand;
        [Inject]
        public void Construct(Hand hand)
        {
            this.hand = hand;
        }
        public override void Act()
        {
            if (hand.Has(ItemToUse))
            {
                Debug.Log("Trying to use");
                module.Value.OnConsume();
                hand.ConsumeItem();
                if (passEvent != null)
                {
                    passEvent.Act();
                }
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