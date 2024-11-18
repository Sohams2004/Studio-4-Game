using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistSound : MonoBehaviour
{
    [SerializeField] private AudioSource startSound;
    [SerializeField] private AudioSource soundAfterXSeconds;
    [SerializeField] private AudioSource soundAfterYSeconds;

    [SerializeField] private float timeForSecondSound = 45f; // Adjustable in Inspector
    [SerializeField] private float timeForThirdSound = 110f; // Adjustable in Inspector

    private float startTime;

    // Flags to ensure sounds only play once
    private bool secondSoundPlayed = false;
    private bool thirdSoundPlayed = false;

    void Start()
    {
        startTime = Time.time; // Record the start time
        startSound.Play();     // Play the start sound
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        // Play the second sound after the specified time if it hasn't been played already
        if (elapsedTime >= timeForSecondSound && !secondSoundPlayed)
        {
            soundAfterXSeconds.Play();
            secondSoundPlayed = true; // Mark the second sound as played
        }

        // Play the third sound after the specified time if it hasn't been played already
        if (elapsedTime >= timeForThirdSound && !thirdSoundPlayed)
        {
            soundAfterYSeconds.Play();
            thirdSoundPlayed = true; // Mark the third sound as played
        }
    }
}
