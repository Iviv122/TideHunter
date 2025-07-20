using Interact;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    [SerializeField] float Length;
    [SerializeField] InputManager input;
    [SerializeField] Hand hand;
    private void Awake()
    {
        input.LeftMouse += Use;
        input.Scroll += Use;
    }
    void Use()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Length))
        {
            if (hit.collider.TryGetComponent<Interactable>(out Interactable thing))
            {
                thing.Interact();
            }
        }
    }
    void Use(Vector2 scroll)
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Length))
        {
            if (hit.collider.TryGetComponent<Scrollable>(out Scrollable thing))
            {
                if (scroll.y > 0)
                {

                    thing.Up();
                }
                else
                {
                    thing.Down();
                }
            }
        }
    }
}