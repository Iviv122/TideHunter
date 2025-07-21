using UnityEngine;

namespace Events
{
    public class EnableObject : Event
    {

        [SerializeField] GameObject item;
        public override void Act()
        {
        }
        public override void Act(float value)
        {
        }
        public override void Act(bool state)
        {
            if (item != null)
            {
                item.SetActive(state);
            }
        }
    }
}