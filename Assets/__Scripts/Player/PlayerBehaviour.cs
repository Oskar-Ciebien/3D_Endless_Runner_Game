using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    // == Serialize Fields ==
    [SerializeField] Sprite deadIcon;
    [SerializeField] Image[] lifeIcons;

    // == Public Fields ==
    public static GameObject player;
    public static GameObject currentPlatform;
    public static bool isDead = false;
    public static float moveSpeed = 2.0f;
    public static int startLives = 3;
    public static int startScore = 0;

    // == Private Fields ==
    private Animator myAnim;
    private float reloadTime = 3.0f;
    private int livesLeft; // Read from the PlayerPrefs

    void Start()
    {
        // Set player to this game object
        player = this.gameObject;
        // Call RunPhantom() from CreateFromPool
        CreateFromPool.RunPhantom();
        // Set myAnim to the Animator Component of the Player
        myAnim = GetComponent<Animator>();

        // Get Lives Left from the PlayerPrefs
        livesLeft = PlayerPrefs.GetInt("LivesLeft");

        // Set the life icons
        UpdateLifeIcons(livesLeft);

        // Player is not dead - Set isDead to false
        isDead = false;
    }

    // Check for User Input
    void Update()
    {
        // If player is dead - Return
        if (isDead == true) return;

        // Get Lives Left from the PlayerPrefs
        livesLeft = PlayerPrefs.GetInt("LivesLeft");

        //print("Player Lives " + livesLeft); // Used for Testing

        // Set the life icons
        UpdateLifeIcons(livesLeft);

        // Call ProcessMovement()
        ProcessMovement();
    }

    // Resets the Player
    public static void ResetPlayer()
    {
        // Set isDead to false
        isDead = false;

        // Set number of platforms to 0 from CreateFromPool
        CreateFromPool.platNum = 0;

        // Set the lives left to the default amount
        PlayerPrefs.SetInt("Score", startScore);

        // Set the lives left to the default amount
        PlayerPrefs.SetInt("LivesLeft", startLives);
    }

    private void ProcessMovement()
    {
        // Jumping - Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set off a jumping animation
            myAnim.SetBool("IsJumping", true);
        }
        // Move Player Left - A Key or Left Arrow
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Translate player to the left
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        // Move Player Right - D Key or Right Arrow
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Translate player to the right
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    // Stops Jump
    public void StopJump()
    {
        // Stop animation for jumping
        myAnim.SetBool("IsJumping", false);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If collided with an object with tag - Death
        if (other.gameObject.tag == "Death")
        {
            // Set off Dead Animation
            myAnim.SetBool("IsDead", true);
            // Set isDead to true (Player Died)
            isDead = true;
            // Take one life
            livesLeft--;
            // Set the new lives
            PlayerPrefs.SetInt("LivesLeft", livesLeft);
            // Update Heart Icons
            UpdateLifeIcons(livesLeft);

            // If no more lives left
            if (livesLeft <= 0)
                // Show death scene after reload time
                Invoke("DeathScene", reloadTime);
            else // Otherwise
            {
                //print("Player Died"); // Used for testing

                // Call a method to restart the scene
                Invoke("RestartScene", reloadTime);
            }
        }
        else // Otherwise
        {
            // Set the currentPlatform to the platform currently standing on
            currentPlatform = other.gameObject;
            //print("Current platform is: " + other.gameObject.tag);

            // Stop Jump
            StopJump();
        }
    } // OnCollisionEnter - END

    public void UpdateLifeIcons(int lives)
    {
        //Debug.Log("Lives Left: " + livesLeft + " Input Lives: " + lives); // Used for testing

        // Go through the lifeIcons
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            // Set the icons
            if (i >= lives)
                lifeIcons[i].sprite = deadIcon;
        }
    }

    // Restart the Game Scene
    public void RestartScene()
    {
        // Load the Game Scene
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // Show the DeathScene - Player Died
    public void DeathScene()
    {
        // Call ResetPlayer()
        ResetPlayer();
        // Load the Death Scene
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player collided with BoxCollider
        if (other is BoxCollider)
            // RunPhantom from CreateFromPool
            CreateFromPool.RunPhantom();
    }
} // Class - END
