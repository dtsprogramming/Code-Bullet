using UnityEngine;

public class LaserRender : MonoBehaviour
{
    [Header("Laser Start and End Points")]
    [SerializeField] private Transform[] startPoints;
    [SerializeField] private Transform[] endPoints;
    [SerializeField] private LineRenderer laserLine;

    [Header("Laser Width Values")]
    [SerializeField] private float widthStart = 0.2f;
    [SerializeField] private float widthEnd = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        laserLine.startWidth = widthStart;
        laserLine.endWidth = widthEnd;
    }

    private void Update()
    {
        RenderLasers();
    }

    private void RenderLasers()
    {
        for (int i = 0; i < startPoints.Length; i++)
        {
            LineRenderer newLine = Instantiate(laserLine, startPoints[i]);

            newLine.SetPosition(0, startPoints[i].position);
            newLine.SetPosition(1, endPoints[i].position);
        }
    }
}
