using UnityEngine;
using UnityEngine.AI;

public class playerDetect : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public float rotationSpeed = 5f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    private Transform player;
    private NavMeshAgent mechAgent;

    #region functions
        void Start()
    {
        mechAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

        void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRadius)
            {
                mechAgent.SetDestination(player.position);

                if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
                {
                    AttackPlayer();
                    lastAttackTime = Time.time;
                }

                HandleDetectedItem(player.gameObject);
            }
        }
    }

    void HandleDetectedItem(GameObject detectedItem)
    {
        detectedItem.SetActive(true);

        // Calculate the direction to the detected item
        Vector3 directionToItem = detectedItem.transform.position - transform.position;

        // Check if the direction vector is not zero
        if (directionToItem != Vector3.zero)
        {
            // Rotate the mech to face the detected item
            Quaternion targetRotation = Quaternion.LookRotation(directionToItem);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Handle the case when the direction vector is zero (optional)
            // For example, you might want to keep the current rotation or perform a different action.
        }
    }


    void AttackPlayer()
    {
        // Implement your attack logic here
        Debug.Log("Attacking Player!");
    }

        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    #endregion
}
