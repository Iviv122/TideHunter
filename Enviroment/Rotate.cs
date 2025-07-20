using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    void Update()
    {
        transform.Rotate(new Vector3(x,y,z));
    }
}
