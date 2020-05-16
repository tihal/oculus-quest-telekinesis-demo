using UnityEngine;

public class telekinesisExplode : MonoBehaviour
{
    // game object for the exploding object prefab
    public GameObject cubeShattered;

    // boolean values to detect if both right and left raycasts have hit the object
    public bool rightHandRay = false;
    public bool leftHandRay = false;

    // float values for increasing object size
    private float x = 0.005f;
    private float y = 0.005f;
    private float z = 0.005f;

    // boolean to see if the enemy should die or not
    private bool enemyDie = false;

    // boolean to flag if we've completed our explosion countdown
    private bool countdown = true;

    // time float to track time
    private float time = 0.0f;

    // how long to wait (in seconds) until enemy dies
    private float explodeCountdown = 3f;

    private void Update()
    {

        // check if our time has exceeded 3 seconds (explodeCountdown)
        if (time > explodeCountdown)
        {
            //explode when false
            countdown = false;
        }

        // run explode script
        triggerExplosion();

        // if the right raycast is no longer hitting an enemy, set our boolean back to false
        if (FindObjectOfType<telekinesisHand>().enemyHit == false)
            {
                rightHandRay = false;
            }

        // if the left raycast is no longer hitting an enemy, set our boolean back to false
        if (FindObjectOfType<telekinesisHandLeft>().enemyHitLeft == false)
        {
            leftHandRay = false;
        }

        // once countdown is false, kill the enemy
        if (!countdown)
        {
            enemyDie = true;
        }

    }

    
    private void triggerExplosion ()
    {
        // if both right hand ray and left hand ray are hitting the object, AND countdown isn't false, do something
        if (rightHandRay && leftHandRay && countdown)
        {
            // grow the game object
            transform.localScale += new Vector3(x, y, z);
            // increase timer
            time += Time.deltaTime;

        } 

        // blow up prefab and destroy
        if (enemyDie == true)
        {
            Instantiate(cubeShattered, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }


}
