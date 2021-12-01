using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureSnapPoint : MonoBehaviour
{
    private bool satisfied = false;
    public static float snapRange = 0.75f;

    public void Start()
    {

    }

    public void Update()
    {
        
    }
    public bool Satisfied()
    {
        return satisfied;
    }
    private bool CompareParentRotations(Transform otherSnapPoint) 
    {
        float angleDiff = Mathf.Abs(gameObject.GetComponentInParent<Transform>().rotation.eulerAngles.y - otherSnapPoint.GetComponentInParent<Transform>().rotation.eulerAngles.y);
        if (angleDiff < 30 || angleDiff > 330) {
            print("satisfied");
            return true;
        }
        else
        {
            return false;
        }
        // comparing angle between two snap points
    }

    public void Delete()
    {
        Destroy(this);
    }

    public Vector3 SnapPointOffset()
    {
        StructureSnapPoint[] allSnapPoints = FindObjectsOfType<StructureSnapPoint>();
        foreach (StructureSnapPoint curr in allSnapPoints)
        {
            if (curr == null)
            {
                continue;
            }

            if (Vector3.Distance(transform.position, curr.transform.position) > 0.0001 && Vector3.Distance(transform.position, curr.transform.position) < snapRange)
            {
                
                return curr.transform.position - transform.position;
            }
        }
        return Vector3.zero;
    }
}
