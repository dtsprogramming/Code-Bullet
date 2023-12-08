using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserRender : MonoBehaviour
{
    [Header("Laser Start and End Points")]
    [SerializeField] private Transform[] startPoints;
    [SerializeField] private Transform[] endPoints;
    [SerializeField] private LineRenderer laserLine;

    [Header("Laser Width Values")]
    [SerializeField] private float widthStart = 0.2f;
    [SerializeField] private float widthEnd = 0.2f;

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        laserLine.startWidth = widthStart;
        laserLine.endWidth = widthEnd;

        ActivateLasers();
    }

    private void FixedUpdate()
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
            Ray ray = new Ray(startPoints[i].position, startPoints[i].right);
            bool cast = Physics.Raycast(ray, out RaycastHit hit, 10000f);
            Vector3 hitPosition = cast ? hit.point : startPoints[i].position + startPoints[i].forward * 1000f;

            lineRenderers[i].SetPosition(0, startPoints[i].position);
            lineRenderers[i].SetPosition(1, hitPosition);

            if (hit.collider.tag == "Sacrifice")
            {
                DissolveController onLaserHit = hit.collider.gameObject.GetComponent<DissolveController>();
                onLaserHit.ZombieDeathAnim();
                onLaserHit.DissolveZombie();
            }
        }
    }
}
