using UnityEngine;
namespace Interact
{
    abstract public class Interactable : MonoBehaviour
    {
        [SerializeField] protected Events.Event[] events;
        abstract public void Interact();
    }
}

