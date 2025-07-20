using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] Transform targetPlace;
    [SerializeField] float t;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,targetPlace.position,t);
    }
}
