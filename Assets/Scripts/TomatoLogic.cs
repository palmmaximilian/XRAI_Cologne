using UnityEngine;
using System.Collections;

/// <summary>
/// This script controls the animation sequence for a tomato can race scene.
/// It manages the visibility and animations of a fan, three tomato can states (idle, run, victory), and a flag.
/// </summary>
public class TomatoRaceController : MonoBehaviour
{
    [Header("Scene Objects")]
    [Tooltip("The fan GameObject with an Animator component.")]
    public GameObject fan;

    [Tooltip("The 'idle' tomato can GameObject.")]
    public GameObject idleCan;

    [Tooltip("The 'run' tomato can GameObject with an Animator component.")]
    public GameObject runCan;

    [Tooltip("The 'victory' tomato can GameObject with an Animator component.")]
    public GameObject victoryCan;

    [Tooltip("The flag GameObject with an Animator component.")]
    public GameObject flag;

    // Private references to the Animator components
    private Animator fanAnimator;
    private Animator runCanAnimator;
    private Animator victoryCanAnimator;
    private Animator flagAnimator;

    /// <summary>
    /// This function is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // Get the Animator components from the assigned GameObjects.
        // Using GetComponentInChildren to be more flexible in case the Animator is on a child object.
        fanAnimator = fan.GetComponentInChildren<Animator>();
        runCanAnimator = runCan.GetComponentInChildren<Animator>();
        victoryCanAnimator = victoryCan.GetComponentInChildren<Animator>();
        flagAnimator = flag.GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// This function is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    void Start()
    {
        // Set up the initial state of the scene.
        SetupScene();
    }

    /// <summary>
    /// Sets the initial visibility of objects and starts the fan animation.
    /// </summary>
    private void SetupScene()
    {
        // By default, the fan's animation should be playing.
        // Make sure the animation clip for the fan has "Loop Time" enabled in its import settings.
        if (fanAnimator != null)
        {
            // Replace "Fan_Spin" with the actual name of your fan's animation state/clip.
            fanAnimator.Play("Fan_Spin");
        }

        // Set the initial visibility for the tomato cans.
        idleCan.SetActive(true);
        runCan.SetActive(false);
        victoryCan.SetActive(false);
    }

    /// <summary>
    /// This is the public function you call to begin the race sequence.
    /// You can call this from a UI button's OnClick() event or from another script.
    /// </summary>
    public void StartRaceSequence()
    {
        // We start a coroutine to handle the sequence of events over time.
        StartCoroutine(RaceCoroutine());
    }

    /// <summary>
    /// The coroutine that handles the step-by-step animation and object visibility sequence.
    /// </summary>
    private IEnumerator RaceCoroutine()
    {
        // --- Step 1: Start the race ---
        // Hide the idle can and show the running can.
        idleCan.SetActive(false);
        runCan.SetActive(true);

        // Play the running and flag animations.
        // Replace "Can_Run" and "Flag_Wave" with your actual animation state/clip names.
        if (runCanAnimator != null)
        {
            runCanAnimator.Play("Can_Run");
        }
        if (flagAnimator != null)
        {
            flagAnimator.Play("Flag_Wave");
        }

        // --- Step 2: Wait for the run animation to finish ---
        // We wait for the length of the running animation before proceeding.
        float runAnimationLength = 0f;
        if (runCanAnimator != null)
        {
            // This gets the length of the currently playing animation clip.
            runAnimationLength = runCanAnimator.GetCurrentAnimatorStateInfo(0).length;
        }
        
        yield return new WaitForSeconds(runAnimationLength);

        // --- Step 3: Victory Lap ---
        // Hide the running can and show the victory can.
        runCan.SetActive(false);
        victoryCan.SetActive(true);

        // Play the victory animation.
        // Make sure this animation has "Loop Time" DISABLED in its import settings so it only plays once.
        // Replace "Can_Victory" with your actual animation state/clip name.
        if (victoryCanAnimator != null)
        {
            victoryCanAnimator.Play("Can_Victory");
        }
    }

    /// <summary>
    /// For easy testing: Press the Space Bar to start the race sequence.
    /// You can remove this Update function if you call StartRaceSequence() from another script or UI element.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRaceSequence();
        }
    }
}
