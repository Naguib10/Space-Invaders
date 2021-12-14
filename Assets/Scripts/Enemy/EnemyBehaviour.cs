using UnityEngine;
using UnityEngine.UI;

// This script controls the behaviour of each single Alien enemy
public class EnemyBehaviour : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip destroySFX;

    public static int enemiesCount;
    public GameObject textDisplay;

    void DisplayText(string inputText)
    {
        //GETTING THE TEXT COMPONENT AND PASSING IT A STRING AS AN ARGUMENT
        Text info = textDisplay.GetComponent<Text>();
        info.text = inputText;
    }

    // Start is called before the first frame update
    void Start()
    {
        //GETTING THE NUMBER OF ENEMIES THROUGH "FindGameObjectsWithTag().Length" THEN DISPLAYING IT AT THE START OF THE GAME
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        DisplayText("Enemies = " + enemiesCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // A function automatically triggerred when another game object with Collider2D component
    // Enters the Collider2D boundaries on this game object
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
		// Check the tag on the other game object. If it's the projectile's tag,
		//  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile")
        {
            audio.PlayOneShot(destroySFX);
            Destroy(gameObject);

            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);

            //UPDATING THE ENEMIES COUNT AFTER THE DESTRUCTION OF THE ENEMY AND PROJECTILE GAME OBJECTS
            enemiesCount--;
            DisplayText("Enemies = " + enemiesCount);
        }
    }

}
