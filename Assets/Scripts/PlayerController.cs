using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header ("General")]
    [Tooltip ("in ms^-1")] [SerializeField] float Speed = 4f;
    [Tooltip("in m")] [SerializeField] float xRange = 4f;
    [Tooltip("in m")] [SerializeField] float yRange = 3f;

    [Header ("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float positionYawFactor = 4f;
    
    [Header("Control-Throw Based")]
    [SerializeField] float controlrollFactor = -30f;
    [SerializeField] float controlPitchFactor = -20f;

    float xThrow, yThrow;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }

    private void OnPlayerDeath() // called by string reference
    {
        isAlive = false;
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlrollFactor; 
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, +xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, +yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
