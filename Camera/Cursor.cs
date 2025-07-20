using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] CameraInput input;
    [SerializeField] float t;
    [SerializeField] Material mat;
    public void Update()
    {

        Color col;
        transform.position = Vector3.Slerp(transform.position, input.mousePos, t);
        if (input.canInteract)
        {
            col = Color.green;
            mat.color = col;
            mat.SetColor("_EmissionColor", col);
        }
        else
        {
            col = Color.white;
            mat.color = col;
            mat.SetColor("_EmissionColor", col);
        }
    }
}
