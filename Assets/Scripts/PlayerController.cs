using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB2D;
    [SerializeField] float moveForce = 5.0f;

    [SerializeField] GameObject TLThrust, BLThrust, TRThrust, BRThrust;
    [SerializeField] TrailRenderer TLTrail, BLTrail, TRTrail, BRTrail;
    //[SerializeField] GameObject TLSfx, BLSfx, TRSfx, BRSfx;
    [SerializeField] GameObject thrusterSFX;

    void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Controls();

        ThrusterSFX();
    }

    void Controls()
    {
        Controller(NewKeyCode.topLeftKey, 1, -1, TLThrust, TLTrail);
        Controller(NewKeyCode.bottomLeftKey, 1, 1, BLThrust, BLTrail);
        Controller(NewKeyCode.topRightKey, -1, -1, TRThrust, TRTrail);
        Controller(NewKeyCode.bottomRightKey, -1, 1, BRThrust, BRTrail);
    }

    void Controller(KeyCode a_KeyCode, int a_XDir, int a_YDir, GameObject a_Thruster, TrailRenderer a_Trail)
    {
        if (Input.GetKey(a_KeyCode))
        {
            playerRB2D.velocity = Vector2.Lerp(playerRB2D.velocity, ((a_XDir * transform.right) + (a_YDir * transform.up)) * moveForce, 0.5f * Time.deltaTime);
            a_Thruster.SetActive(true);
            a_Trail.emitting = true;
        }
        else
        {
            a_Thruster.SetActive(false);
            a_Trail.emitting = false;
        }
    }

    void ThrusterSFX()
    {
        if (Input.GetKey(NewKeyCode.topLeftKey) || Input.GetKey(NewKeyCode.bottomLeftKey) || Input.GetKey(NewKeyCode.topRightKey) || Input.GetKey(NewKeyCode.bottomRightKey))
        {
            thrusterSFX.SetActive(true);
        }
        else
        {
            thrusterSFX.SetActive(false);
        }
    }
}
