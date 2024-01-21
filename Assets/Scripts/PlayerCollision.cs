using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    Vector3 _checkpointPos;

    public static bool hasRedCard = false;
    public static bool hasGreenCard = false;
    public static bool hasBlueCard = false;
    public static bool hasPurpleCard = false;

    void Start()
    {
        _checkpointPos = transform.position;

        hasRedCard = false;
        hasGreenCard = false;
        hasBlueCard = false;
        hasPurpleCard = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyKill"))
        {
            transform.position = _checkpointPos;
        }

        if (collision.CompareTag("Checkpoint"))
        {
            _checkpointPos = collision.transform.position;
            AudioManager.Instance.PlaySFX("ClickSFX");
        }

        if (collision.CompareTag("Escape"))
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Unlocker"))
        {
            UnlockCards(collision);

            UnlockDoors(collision);
        }
    }

    void UnlockCards(Collision2D a_Collider2D)
    {
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isRedCard)
        {
            hasRedCard = true;
            Destroyer(a_Collider2D);
        }
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isGreenCard)
        {
            hasGreenCard = true;
            Destroyer(a_Collider2D);
        }
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isBlueCard)
        {
            hasBlueCard = true;
            Destroyer(a_Collider2D);
        }
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isPurpleCard)
        {
            hasPurpleCard = true;
            Destroyer(a_Collider2D);
        }
    }

    void UnlockDoors(Collision2D a_Collider2D)
    {
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isRedDoor && hasRedCard)
        {
            Destroyer(a_Collider2D);
        }
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isGreenDoor && hasGreenCard)
        {
            Destroyer(a_Collider2D);
        }
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isBlueDoor && hasBlueCard)
        {
            Destroyer(a_Collider2D);
        }
        if (a_Collider2D.gameObject.GetComponent<Unlocker>().isPurpleDoor && hasPurpleCard)
        {
            Destroyer(a_Collider2D);
        }
    }

    void Destroyer(Collision2D a_Collider2D)
    {
        Destroy(a_Collider2D.gameObject);
    }
}
