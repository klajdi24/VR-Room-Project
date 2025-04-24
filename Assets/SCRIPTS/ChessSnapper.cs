using UnityEngine;
using System.Collections.Generic;

public class ChessSnapper : MonoBehaviour
{
    public List<Transform> legalSquares; // Assign in Inspector or dynamically
    public float snapThreshold = 0.2f; // How close to a square before snapping

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Delay a bit to let it settle
        Invoke("TrySnapToSquare", 0.1f);
    }

    void TrySnapToSquare()
    {
        Transform closest = null;
        float closestDist = Mathf.Infinity;

        foreach (Transform square in legalSquares)
        {
            float dist = Vector3.Distance(transform.position, square.position);
            if (dist < closestDist)
            {
                closest = square;
                closestDist = dist;
            }
        }

        if (closest != null && closestDist < snapThreshold)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = closest.position;
        }
    }
}
