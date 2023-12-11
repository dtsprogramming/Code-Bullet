using System.Collections.Generic;
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

    [Header("Laser Toggles")]
    [SerializeField] private float rayDistance = 100f;

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        laserLine.startWidth = widthStart;
        laserLine.endWidth = widthEnd;

        ActivateLasers();
    }

    private void LateUpdate()
    {
        RenderLasers();
    }

    private void ActivateLasers()
    {
        for (int i = 0; i < startPoints.Length; i++)
        {
            LineRenderer newLine = Instantiate(laserLine, startPoints[i]);

            newLine.SetPosition(0, startPoints[i].position);
            newLine.SetPosition(1, endPoints[i].position);

            lineRenderers.Add(newLine);
        }
    }

    private void RenderLasers()
    {
        for(int i = 0; i < lineRenderers.Count; i++)
        {
            Vector3 direction = endPoints[i].position - startPoints[i].position;

            Ray ray = new Ray(startPoints[i].position, direction);
            Debug.DrawRay(startPoints[i].position, direction * rayDistance, Color.green);
            bool cast = Physics.Raycast(ray, out RaycastHit hit, rayDistance);
            Vector3 hitPosition = cast ? hit.point : endPoints[i].position;

            lineRenderers[i].SetPosition(0, startPoints[i].position);
            lineRenderers[i].SetPosition(1, hitPosition);

            if (hit.collider.CompareTag("Sacrifice"))
            {
                DissolveController onLaserHit = hit.collider.gameObject.GetComponent<DissolveController>();
                onLaserHit.ZombieDeathAnim();
                onLaserHit.DissolveZombie();
            }
            else
            {
                continue;
            }
        }
    }
}
