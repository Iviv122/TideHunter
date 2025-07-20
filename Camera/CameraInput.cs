using Interact;
using UnityEngine;
public class CameraInput : MonoBehaviour
{

    [SerializeField] float Length;
    public Vector3 mousePos;
    public bool canInteract;
    public void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,Length))
        {
            this.mousePos = hit.point;
            if (hit.collider.TryGetComponent<Interactable>(out Interactable interact) || hit.collider.TryGetComponent<Scrollable>(out Scrollable scroll))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
        else
        {
            mousePos = new Vector3(0,0,0);
            canInteract = false;
        }
    }
}