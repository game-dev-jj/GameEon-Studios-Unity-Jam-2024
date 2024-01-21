using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] Transform enemy;

    Vector3 nextPos;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private float enemySpeed;

    float objectOnAngle;

    void Start()
    {
        nextPos = pos1.position;
    }

    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;

            FacingTowardsObject();
        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;

            FacingTowardsObject();
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, enemySpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemySpeed = 3.5f;

            nextPos = collision.gameObject.transform.position;

            Vector3 directionOfObject = collision.gameObject.transform.position - transform.position;
            objectOnAngle = Mathf.Atan2(directionOfObject.y, directionOfObject.x) * Mathf.Rad2Deg;
            gameObject.GetComponent<Rigidbody2D>().rotation = objectOnAngle - 90.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextPos = pos1.position;

            FacingTowardsObject();
        }
    }

    private void FacingTowardsObject()
    {
        Vector3 directionOfObject = nextPos - transform.position;
        objectOnAngle = Mathf.Atan2(directionOfObject.y, directionOfObject.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Rigidbody2D>().rotation = objectOnAngle - 90.0f;
    }
}