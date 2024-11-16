using UnityEngine;

public class BowSound : MonoBehaviour
{
    [SerializeField] private AudioSource weaponSound; // AudioSource for the weapon sound (Bow, IceWeapon, or FireWeapon)

    private Animator weaponAnimator;

    private void Start()
    {
        // Get the Animator component from the same GameObject (e.g., Bow, IceWeapon, or FireWeapon)
        weaponAnimator = GetComponent<Animator>();
    }

    // This method will be called by the animation event
    public void PlaySound()
    {
        if (weaponSound != null)
        {
            weaponSound.Play();  // Play the sound when the animation reaches the trigger point
        }
    }
}
