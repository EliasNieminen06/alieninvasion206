using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform gunTransform; // The transform of the gun or shooting point
    public TrailRenderer trailRenderer;
    public float raycastDistance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Cast a ray from the gunTransform forward
        Ray ray = new Ray(gunTransform.position, gunTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // If the ray hits something, set the end position to the hit point
            trailRenderer.Clear();
            trailRenderer.AddPosition(gunTransform.position);
            trailRenderer.AddPosition(hit.point);
        }
        else
        {
            // If the ray doesn't hit anything, set the end position to the limit
            Vector3 endPoint = ray.GetPoint(raycastDistance);
            trailRenderer.Clear();
            trailRenderer.AddPosition(gunTransform.position);
            trailRenderer.AddPosition(endPoint);
        }
    }
}
