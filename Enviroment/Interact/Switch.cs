using UnityEngine;
namespace Interact
{
    public class Switch : Interactable
    {
        [SerializeField] bool state = false;
        [SerializeField] bool StateOnStart = false;
        public void Start()
        {
            state = StateOnStart;
            foreach (Events.Event item in events)
            {
                item.Act(state);
            }
        }

        public override void Interact()
        {
            state = !state;
            foreach (Events.Event item in events)
            {
                item.Act(state);
            }
        }
    }
}
