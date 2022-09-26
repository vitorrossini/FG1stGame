using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] [Range(3, 30)] private int lineSegmentCount = 20;
    [SerializeField] public GameObject projectilePrefab;

    private List<Vector3> linePoints = new List<Vector3>();

    #region Singleton

    public static Aiming Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / projectilePrefab.GetComponent<Rigidbody>().mass) * Time.fixedDeltaTime;
        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;
        float stepTime = FlightDuration / lineSegmentCount;
        linePoints.Clear();

        for(int i = 0; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i; // change in time

            Vector3 MovementVector = new Vector3(
                                          velocity.x* stepTimePassed,
                                          velocity.y* stepTimePassed -0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                                          velocity.z* stepTimePassed
                                          );

        RaycastHit hit;
        if (Physics.Raycast(startingPoint, -MovementVector, out hit, MovementVector.magnitude))
        {
                break;
        }

            linePoints.Add(-MovementVector + startingPoint);
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());

    }                                                       

    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }

    
}
