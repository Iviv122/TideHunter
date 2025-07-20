using UnityEngine;
namespace Interact
{
    abstract public class Scrollable : MonoBehaviour
    {

        [SerializeField] protected Events.Event[] UpEvents;
        [SerializeField] protected Events.Event[] DownEvents;
        float Value;
        abstract public void Up();
        abstract public void Down();
    }

}