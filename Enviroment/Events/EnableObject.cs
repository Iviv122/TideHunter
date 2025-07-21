using UnityEngine;

namespace Events
{
    public class EnableObject : Event
    {

        [SerializeField] GameObject item;
        public override void Act(bool state)
        {
            if (item != null)
            {
                item.SetActive(state);
            }
        }
    }
}