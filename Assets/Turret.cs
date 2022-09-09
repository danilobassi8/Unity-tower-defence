using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    [Header("Attributes")]
    public float range = 15f;
    public float rotationSpeed = 10;
    public float fireRate = 1f;
    private float fireCountdown = 0;

    [Header("Required to work")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    private Transform target;
    public Transform firePoint;
    public GameObject bulletPrefab;


    private void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update() {
        if (target == null) {
            return;
        }

        RotateToTarget();
        FireLogic();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void RotateToTarget() {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void FireLogic() {
        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bulletGO.GetComponent<Bullet>();
        Debug.Log(bulletScript);
        if (bulletGO != null) {
            bulletScript.Seek(target);
        }
    }

    private void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearEnemy = enemy;
            }
        }
        if (nearEnemy != null && shortestDistance <= range) {
            target = nearEnemy.transform;
        }
    }
}
