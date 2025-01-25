using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject cubeDebrisPrefab; // Assign your CubeDebris prefab here
    public int numberOfCubes = 10;    // Number of cubes to spawn
    public float explosionForce = 10f; // Force of the explosion
    public float explosionRadius = 5f; // Radius of the explosion

    public void Explode()
    {
        // Spawn cubes in a random sphere around the explosion point
        for (int i = 0; i < numberOfCubes; i++)
        {
            // Calculate random position within the explosion radius
            Vector3 randomPosition = Random.insideUnitSphere * explosionRadius;
            randomPosition += transform.position; // Add the enemy's position

            // Instantiate the cube debris
            GameObject cubeDebris = Instantiate(cubeDebrisPrefab, randomPosition, Quaternion.identity);

            // Add force to the cube debris (if it has a Rigidbody)
            Rigidbody rb = cubeDebris.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calculate direction vector from the explosion center to the debris
                Vector3 explosionDirection = cubeDebris.transform.position - transform.position;

                // Apply force outwards in the calculated direction
                rb.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
            }

            // Optionally, destroy the cube debris after a certain time
            //Destroy(cubeDebris, 2f); // Destroy after 2 seconds
        }
    }
}