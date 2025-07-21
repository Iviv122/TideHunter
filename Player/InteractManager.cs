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
}