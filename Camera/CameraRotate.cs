using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] float sensetivityX;
    [SerializeField] float sensetivityY;
    [SerializeField] float interpolationSpeed;
    [SerializeField] Transform orientation;
    float rotationX;
    float rotationY;

    public void Awake()
    {
        inputManager.Look += Look;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    public void Look(Vector2 dir)
    {

        float x = dir.x * sensetivityX;
        float y = dir.y * sensetivityY;

        rotationY += x;
        rotationX -= y;

        rotationX = Mathf.Clamp(rotationX, -89, 89);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotationX, rotationY, 0), interpolationSpeed);
        orientation.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
