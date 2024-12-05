using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAli : MonoBehaviour
{
    public Animator startButtonAnimator; // Animator for Start button
    public Animator exitButtonAnimator;  // Animator for Exit button
    public string animationTrigger = "PlayAnimation"; // Shared animation trigger
    public string sceneToLoad = "AliScene2"; // Scene to load when starting the game

    public void StartGame()
    {
        // Play the Start button animation
        startButtonAnimator.SetTrigger(animationTrigger);

        // Wait for the animation to finish, then load the scene
        StartCoroutine(WaitForAnimationAndExecute(startButtonAnimator, () => SceneManager.LoadScene(sceneToLoad)));
    }

    public void ExitGame()
    {
        // Play the Exit button animation
        exitButtonAnimator.SetTrigger(animationTrigger);

        // Wait for the animation to finish, then quit the game
        StartCoroutine(WaitForAnimationAndExecute(exitButtonAnimator, () => Application.Quit()));
    }

    private IEnumerator WaitForAnimationAndExecute(Animator animator, System.Action onComplete)
    {
        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Execute the provided action
        onComplete.Invoke();
    }


}
