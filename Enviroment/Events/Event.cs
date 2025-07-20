using UnityEngine;
namespace Events
{
    abstract public class Event : MonoBehaviour
    {
        abstract public void Act();

        abstract public void Act(float value);
        abstract public void Act(bool state);
    }
}
