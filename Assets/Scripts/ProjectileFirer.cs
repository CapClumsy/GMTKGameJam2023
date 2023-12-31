using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFirer : MonoBehaviour
{
    [SerializeField]
    public Transform[] fireSources;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip fireSound;

    public GameObject[] FireInDirection(GameObject projectilePrefab, Vector2 direction)
    {
        GameObject[] projectiles = new GameObject[fireSources.Length];
        for (int i = 0; i < fireSources.Length; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, fireSources[i].transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().direction = direction.normalized;
            projectiles[i] = projectile;
        }
        audioSource.PlayOneShot(fireSound);
        return projectiles;
    }

    public GameObject FireOneInDirection(GameObject projectilePrefab, Vector2 direction, int fireSourceIndex = 0)
    {
        GameObject projectile = Instantiate(projectilePrefab, fireSources[fireSourceIndex].transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().direction = direction.normalized;
        return projectile;
    }

    /// Only use if the ProjectileFirer has one fireSource
    public GameObject FireAt(GameObject projectilePrefab, Vector2 direction, int fireSourceIndex = 0)
    {
        return FireInDirection(projectilePrefab, (direction - new Vector2(fireSources[fireSourceIndex].transform.position.x, fireSources[fireSourceIndex].transform.position.y)).normalized)[0];
    }
}
