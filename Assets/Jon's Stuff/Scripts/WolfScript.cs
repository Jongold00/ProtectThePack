using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfScript : MonoBehaviour
{
    public int damage = 5;
    public Animator anim;
    public float stoppingDistance = 3.0f;
    public float attackRate = 3.0f;
    float attackTimer;


    WallBehavior targetWall;
    SheepAI targetSheep;
    Transform target;

    public bool sheepAttackable = true;

    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        targetWall = GetAttackWall();
        targetSheep = GetAttackSheep();

        GetNewTarget();
        nav.stoppingDistance = stoppingDistance;

    }

    // Update is called once per frame
    void Update()
    {
        GetNewTarget();

        //print(nav.remainingDistance);

        if (Vector3.Distance(nav.destination, transform.position) <= stoppingDistance)
        {
            PauseNav();
            anim.SetBool("Attacking", true);
            
            if (attackTimer <= 0.0f)
            {
                attackTimer = attackRate;
                AttackTarget();
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }

        else
        {
            if (anim.GetBool("Attacking"))
            {
                anim.SetBool("Attacking", false);
            }
        }
    }

    void GetNewTarget()
    {
        targetSheep = GetAttackSheep();
        targetWall = GetAttackWall();

        if (targetSheep && CalculateSheepPath(targetSheep.transform))
        {
            nav.SetDestination(targetSheep.transform.position);
            target = targetSheep.transform;
        }
        else
        {
            nav.SetDestination(targetWall.transform.position);
            target = targetWall.transform;
        }
        


    }

    bool CalculateSheepPath(Transform sheepTransform)
    {
        NavMeshPath navMeshPath = new NavMeshPath();

        nav.CalculatePath(sheepTransform.position, navMeshPath);
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private SheepAI GetAttackSheep()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (SheepAI curr in FindObjectsOfType<SheepAI>())
        {
            float dist = Vector3.Distance(curr.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = curr.transform;
                minDist = dist;
            }
        }
        if (tMin)
        {
            return tMin.GetComponent<SheepAI>();
        }
        return null;
    }
     private WallBehavior GetAttackWall()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
            foreach (WallBehavior curr in FindObjectsOfType<WallBehavior>())
            {
                float dist = Vector3.Distance(curr.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = curr.transform;
                    minDist = dist;
                }
            }
        if (tMin)
        {
            return tMin.GetComponent<WallBehavior>();
        }
        return null;

    }

    private void AttackTarget()
    {
        if (target.CompareTag("sheep"))
        {
            target.GetComponent<SheepAI>().LoseHealth(damage);
        }

        if (target.CompareTag("wall"))
        {
            target.GetComponent<WallBehavior>().LoseHealth(damage);
        }
    }

    void PauseNav()
    {
        nav.SetDestination(transform.position);
    }

}
