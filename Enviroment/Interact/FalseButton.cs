using Events;

namespace Interact
{
    public class FalseButton : Interactable
    {
        public override void Interact()
        {
            foreach (Event item in events)
            {
                item.Act(false);
            }
        }
    }
}