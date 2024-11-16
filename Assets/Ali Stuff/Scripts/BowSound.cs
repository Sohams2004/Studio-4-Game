using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSound : MonoBehaviour
{
     [SerializeField] private AudioSource bowSound; // The AudioSource for the weapon sound

    private Animator weaponAnimator;

    private void Start()
    {
        // Attempt to find an Animator on Bow, IceWeapon, or FireWeapon child objects
        weaponAnimator = GetComponent<Animator>();  // Attach this to the same GameObject as the animator
    }

    // This method will be called by the animation event
    public void PlaySound()
    {
        if (bowSound != null)
        {
            bowSound.Play();  // Play sound when animation reaches the trigger point
        }
    }
}
