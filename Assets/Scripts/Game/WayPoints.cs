using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform[] FillUpListOfWayPoints(Transform[] wayPoints)
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = gameObject.transform.GetChild(i);
        }

        return wayPoints;
    }
}
