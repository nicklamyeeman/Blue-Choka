using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour 
{
    private NPCBehavior NPCBehavior;
    public GameObject destination;
    private NavMeshAgent navMeshAgent;
    private NPCAnimation NPCAnimation;
    Vector3 target;

    void Start()
    {
        NPCBehavior = GetComponent<NPCBehavior>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        NPCAnimation = GetComponent<NPCAnimation>();
        navMeshAgent.isStopped = true;
        HeadForDestintation();
        // Invoke("HeadForDestintation", 1f);
    }

    public void HeadForDestintation()
    {
        // print("Rotation: " + rotation);
        NPCAnimation.SetWalkingAnimation();
        navMeshAgent.isStopped = false;
        target = destination.transform.position;
        SpotBehavior spot = destination.GetComponent<SpotBehavior>();
        spot.isTaken = true;
        NPCBehavior.Rotation = spot.rotation;
        NPCBehavior.IsTalking = spot.isPair;
        navMeshAgent.SetDestination(target);
        // Debug.Log("Remaining distance: " + navMeshAgent.remainingDistance);
        // Debug.Log("Stopping distance: " + navMeshAgent.stoppingDistance);
        // Debug.Log("Path status: " + navMeshAgent.hasPath);
    }

    public void Update()
    {
        if (navMeshAgent && !navMeshAgent.pathPending && navMeshAgent.isStopped == false) {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f) {
                    // Debug.Log("Arrived");
                    navMeshAgent.isStopped = true;
                    gameObject.transform.eulerAngles = new Vector3(
                        gameObject.transform.eulerAngles.x,
                        NPCBehavior.Rotation,
                        gameObject.transform.eulerAngles.z
                    );
                    NPCAnimation.SetIdleAnimation();
                    if (destination.GetComponent<SpotBehavior>().isForOrder == true) {
                        GetComponent<OrderEvent>().TriggerText();
                    }
                }
            }
        }
    }
}