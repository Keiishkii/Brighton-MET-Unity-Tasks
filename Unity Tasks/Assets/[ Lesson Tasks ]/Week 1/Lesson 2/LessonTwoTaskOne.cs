using System;
using UnityEngine;

[ExecuteInEditMode]
public class LessonTwoTaskOne : MonoBehaviour
{
    public int enemyHealth;
    
    // In C# there are 4 main types of loops:
    /*
        for:            for loops have 3 stages, initial assignment, condition checking, and modification. These are usually used with lists or repeating tasks where you know the ammount of times you need to loop.
        foreach:        foreach loops iterate over collections, these are very simular to for loops but deal with iteration within themselves.
        while:          while loops are useful for situations in which you don't know how many times something must repeat. They will loop forever while their condition is true. (very simular to for loops just without the additional assignment and modification stages)
        do while:       exact same as a while loop, but they will always run at least once before checking the condition.
    */

    public void Update()
    {
        // Here is an example of a for loop
        int number = 0;
        for (int i = 0; i < 10; i++)
        {
            // each time this loop runs it will execute the code inside this block, (denoted by the curly braces '{}')    
            number += 15;
        }
        
        // Breaking this down:
        /*
            We assign a variable 'i' with the value zero.
            'i' is then tested (in the same was as an 'if' statement) to see if it is less than 10, if so the contents of the block below the loop executes
            Finally we run i++, this is actually shorthand for (i = i + 1) of which will increase the value of i to 1 more than it currently is. 
        */
        
        // After the loop finishes executing, it will have ran through 10 times.
        // Resulting in number being equal to 150, (0 + 15 * 10)
        //Debug.Log(number); <-- feel free to comment out the log and check for yourself! You can also change the numbers in the loop!

        number = 0;
        
        int j = 0;
        while (j < 20) // <-- do not set this to always true, you will crash Unity... -_-
        {
            number += 6;
            j++;
        }
        
        // 'while' loops are very simular in behaviour to for loops, the only difference is we manage the condition ourselves, in the example above we are using a counter to count up to 20 again.
        // However, we could easily instead use it to search for an object in a list or to do something forever until something external stops it.
        // In this case however, number will count up and be equal to 120, (0 + 6 * 20)
        //Debug.Log(number); <-- feel free to comment out the log and check for yourself! You can also change the numbers in the loop!

        // Do whiles are effectivly the same as a while loop, however we check the condition at the end of the loop instead of before it runs.
        // This gives the little bonus that we can force a loop to execute at least once.
        
        do
        {
            
        } while (10 < 0); // <-- Always false, yet will still run the loop at least once.
        
        
        
        // To complete this task, we will assume an enemy has appeared.
        // His health is 100.
        
        enemyHealth = 100;

        // Use a while loop to slowly cut away at the enemy health until it reaches zero.
        // For the sake or not crashing Unity while you have a play around with this, I have limited the number of iterations to 100 using the iterationCount variable.

        int iterationCount = 0;
        while (enemyHealth > 0 && iterationCount < 100)
        {
            // subtract from the enemy health here!
            
            iterationCount++;
        }
        
        // If by the time the loop exits, the enemy has no health, the task will be considered completed!
        // You can view enemy health in the inspector on the Task4 component.
    }
}
