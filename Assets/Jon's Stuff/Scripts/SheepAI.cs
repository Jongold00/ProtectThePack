using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepAI : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public float wanderDistance;
    public float timeBeforeNextWander;
    public float stoppingDistance;
    public float currentWalkTime;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        timeBeforeNextWander = Random.Range(2f, 5f);
        nav.SetDestination(GetNewWanderDestination(wanderDistance));

    }

    // Update is called once per frame
    void Update()
    {
       if (nav.remainingDistance <= stoppingDistance)
        {
            anim.SetBool("Stopped", true);
            timeBeforeNextWander -= Time.deltaTime;
            if (timeBeforeNextWander <= 0)
            {
                timeBeforeNextWander = Random.Range(2f, 5f);
                nav.SetDestination(GetNewWanderDestination(wanderDistance));
                anim.SetBool("Stopped", false);
            }
        }
    }

    private Vector3 GetNewWanderDestination(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    #region Health
    public int health = 50;

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyMe();
        }
    }

    public void GainHealth(int heal)
    {
        health += heal;
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    #endregion Health
}
