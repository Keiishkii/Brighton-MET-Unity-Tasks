using UnityEngine;

public class LessonTwoTaskTwo : MonoBehaviour
{
    public string taskOutput;
    public bool enemyPresent;
    public int playerHealth;
    public int stepsTaken;
    
    
    // Functions are ways of keeping code organised and calling it from different locations.
    // For this exercise the inspector has 3 buttons, each are hooked up to 'call' the functions below.
    // Try pressing these buttons, you should see that the debug messages are appearing in the console.

    
    
    public void OnWalkButtonPressed()
    {
        Debug.Log("Walk Button Pressed");
        TakeAStep(); // <- This call the take a step function below;
    }

    public void OnHealButtonPressed()
    {
        Debug.Log("Heal Button Pressed");
    }

    public void OnAttackButtonPressed()
    {
        Debug.Log("Attack Button Pressed");
    }

    
    
    // Below is an example of a function with both a return type (the 'int' after public, signifying that this function has the purpose of calculating something),
    // and a parameter (a parameter is a value passed into a function, in this case 'int damage')
    
    // Return types are great for functions that perform a lot of work or are used often to calculate a value, a good example would be the maths function 'a = Mathf.Sin(x)'.
    // In this case the Sin function is used in place of having to write out the hard calculations everytime you might need to use it.
    
    // The parameter is used to have options or inputs with a function, the RecalculatePlayerHealth function below allows for us to deal a variable amount of damage to the player.
    
    private bool RecalculatePlayerHealth(int damage)
    {
        playerHealth -= damage; // <- we use damage to remove from the players health.

        if (playerHealth > 0) return true; // <- returning true from the function to show the player is still alive.
        return false; // <- returning false from the function to show the player is dead.
    }
    
    private void TakeAStep()
    {
        if (enemyPresent)
        {
            bool playerAlive = RecalculatePlayerHealth(30);
            if (!playerAlive) // Reset the players progress on death.
            {
                Debug.Log("Player Dead");
                playerHealth = 100;
                stepsTaken = 0;
            }
        }
        else
        {
            stepsTaken++;
            enemyPresent = Random.Range(0, 100) <= 50; // <- this is how you could do a random output. For now, don't worry about it
        }
    }
    
    
    // To complete this task your job is to write two new functions Heal and Attack.
    // Call these both from the OnHealButtonPressed and OnAttackButtonPressed fucntions (in the same way as TakeAStep is called from OnWalkButtonPressed)
    
    // The Attack function should kill the enemy infront of the player, (do this by setting the 'enemyPresent' variable to false)
    // The Heal function should increase the players health, in the event that an enemy has dealt damage. Try using a parameter to do this! (Something like 'private void Heal(int healthHealed)')
    
    // The victory condition is taking 10 steps, using only the buttons in the inspector! Good luck!
}
