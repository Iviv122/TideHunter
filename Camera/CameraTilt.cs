using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    [Header("Observing")]

    [SerializeField] Transform pivot;
    [SerializeField] float t;
    [Header("Offseting")]
    [SerializeField] float m; // normal 10 and boosted 25
    [SerializeField] Vector2 curOffset = new Vector2(0, 0);
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        mousePos -= new Vector2(0.5f,0.5f);

        curOffset.x = mousePos.x;
        curOffset.y = mousePos.y;

        Vector3 targetPos = new Vector3(pivot.position.x,pivot.position.y) + new Vector3(curOffset.x*m, curOffset.y*m, 0); 

        transform.position = Vector3.Lerp(transform.position,targetPos,t);
    }
}
