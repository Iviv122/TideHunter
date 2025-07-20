using Events;

namespace Interact
{
    public class TrueButton : Interactable
    {
        public override void Interact()
        {
            foreach (Event item in events)
            {
                item.Act(true);
            }
        }
    }
}