using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 10;

    private int pointIndex = 0;
    private Transform target;
    private float acceptedOffset = 0.5f;

    private void Start() {
        target = Waypoints.points[0];
    }

    private void Update() {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= acceptedOffset) {
            pointIndex++;
            if (pointIndex >= Waypoints.points.Length) {
                Destroy(gameObject);
                return;
            }
            else {
                target = Waypoints.points[pointIndex];
            }
        }

    }
}
