using UnityEngine;

namespace Events
{
    public class EnableComponent : Event
    {

        [SerializeField] MonoBehaviour item;
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
                item.enabled = state;
            }
        }
    }
}