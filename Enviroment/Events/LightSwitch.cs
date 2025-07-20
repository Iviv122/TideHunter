using UnityEngine;

namespace Events
{
    public class LightSwitch : Event
    {

        [SerializeField] Light[] lightSources;
        public override void Act()
        {
        }
        public override void Act(float value)
        {

        }
        public override void Act(bool state)
        {
            foreach (var item in lightSources)
            {
                if (item != null)
                {

                    item.enabled = state;
                }
            }
        }
    }
}