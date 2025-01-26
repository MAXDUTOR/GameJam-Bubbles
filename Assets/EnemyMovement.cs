using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    public Transform playerTransform;
    void Update()
    {
        Vector3 playerPositionXZ = new Vector3(playerTransform.position.x, 0f, playerTransform.position.z);

        Vector3 enemyPositionXZ = new Vector3(transform.position.x, 0f, transform.position.z);

        Vector3 direction = (playerPositionXZ - enemyPositionXZ).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        Vector3 directionToPlayer = playerTransform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        transform.rotation = targetRotation;
    }
}