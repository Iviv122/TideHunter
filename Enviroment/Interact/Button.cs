using Events;

namespace Interact
{
    public class Button : Interactable
    {
        public override void Interact()
        {
            foreach (Event item in events)
            {
                item.Act();
            }
        }
    }
}