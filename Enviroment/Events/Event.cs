using UnityEngine;
namespace Events
{
    abstract public class Event : MonoBehaviour
    {
        virtual public void Act()
        {

        }

        virtual public void Act(float value)
        {

        }
        virtual public void Act(bool state)
        {

        }
    }
}
