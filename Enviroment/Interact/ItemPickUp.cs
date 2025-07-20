using Items;
using UnityEngine;
using VContainer;
namespace Interact
{
    public class ItemPickUp : Interactable
    {
        [SerializeField] Item item;
        private Hand hand;
        [Inject]
        public void Construct(Hand hand)
        {
            this.hand = hand;
        }
        public override void Interact()
        {
            if (hand.isEmpty())
            {
                hand.TakeItem(item);
                Destroy(gameObject);
            }
        }

    }
}