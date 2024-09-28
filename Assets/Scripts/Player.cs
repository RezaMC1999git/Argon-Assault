using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 6.5f;
    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -12f;
    [Header("Control-Throw Based")]
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controlRowFactor = -2f;
    [Header("Guns")]
    [SerializeField] GameObject[] Guns;
    [SerializeField] AudioSource deathSFX;

    bool isControllEnabled = true;
    float xThrow, yThrow;
    void Update()
    {
        if (isControllEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRowFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
            SetGunsActive(true);
        else
            SetGunsActive(false);
    }
    void SetGunsActive(bool isActive)
    {
        foreach(GameObject gun in Guns)
        {
            var Emission = gun.GetComponent<ParticleSystem>().emission;
            Emission.enabled = isActive;
        }
    }
    void OnPlayerDeath()
    {
        PlayerPrefs.SetInt("SCORE",0);
        deathSFX.gameObject.SetActive(true);
        isControllEnabled = false;
    }
}
