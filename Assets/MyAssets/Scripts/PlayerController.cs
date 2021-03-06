using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
///using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Tools")]
    //[SerializeField] InputAction movement;
    // Start is called before the first frame update
    [Tooltip("How fast ship moves up and down")][SerializeField] float moveSpeed = 1f;
    [Tooltip("Horizontal move limits")][SerializeField] float xRange = 5f;
    [Tooltip("Vertical move limits")][SerializeField] float yRange = 5f;
    [Tooltip("Select the lasers you want to control")][SerializeField] GameObject[] lasers;

    [Header("Screen position flying tuning")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Input position flying tuning")]
    [SerializeField] float controlPitchFactor = -10f;    
    [SerializeField] float controlRollFactor = -10f;

    float xThrow, yThrow;
        
    /*private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }*/

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        
    }

    void ProcessFiring()
    {
        
        if (Input.GetButton("Fire1"))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }

    void SetLaserActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isActive;
        }

    }
           

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = transform.localPosition.x + xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        /*float horizontalThrow = movement.ReadValue<Vector2>().x;
         Debug.Log(horizontalThrow);
         float verticalThrow = movement.ReadValue<Vector2>().y;
         Debug.Log(verticalThrow);*/

        xThrow = Input.GetAxis("Horizontal");

        yThrow = Input.GetAxis("Vertical");

        float xPos = xThrow * moveSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xPos;
        float clampXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yPos = yThrow * moveSpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yPos;
        float clampYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }
}
