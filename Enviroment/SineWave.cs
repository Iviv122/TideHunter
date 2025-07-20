using UnityEngine;

public class SineWave : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] int points;
    private float a = 0;

    void Draw()
    {
        line.positionCount = points;
        for (int x = 0; x < points; x++)
        {
            float y = Mathf.Sin(x+a);
            line.SetPosition(x, new Vector3(x, y, 0));
        }
    }
    void Update()
    {
        Draw();
        a += 0.1f;
    }
}