using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForSounds : MonoBehaviour
{
     [SerializeField] private Animator animator; // Reference to the Animator component
    [SerializeField] private float firstAnimationTime = 10f; // Time to trigger the first animation (seconds)
    [SerializeField] private float secondAnimationTime = 45f; // Time to trigger the second animation (seconds)
    [SerializeField] private float thirdAnimationTime = 110f; // Time to trigger the third animation (seconds)

    [SerializeField] private string firstAnimationTrigger = "FirstAnimation"; // Name of the first animation trigger
    [SerializeField] private string secondAnimationTrigger = "SecondAnimation"; // Name of the second animation trigger
    [SerializeField] private string thirdAnimationTrigger = "ThirdAnimation"; // Name of the third animation trigger

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime; // Increase time as the game runs

        // Play the first animation at the specified time
        if (elapsedTime >= firstAnimationTime)
        {
            animator.SetTrigger(firstAnimationTrigger);
            firstAnimationTime = float.MaxValue; // Prevent the animation from playing again
        }

        // Play the second animation at the specified time
        if (elapsedTime >= secondAnimationTime)
        {
            animator.SetTrigger(secondAnimationTrigger);
            secondAnimationTime = float.MaxValue; // Prevent the animation from playing again
        }

        // Play the third animation at the specified time
        if (elapsedTime >= thirdAnimationTime)
        {
            animator.SetTrigger(thirdAnimationTrigger);
            thirdAnimationTime = float.MaxValue; // Prevent the animation from playing again
        }
    }
}
