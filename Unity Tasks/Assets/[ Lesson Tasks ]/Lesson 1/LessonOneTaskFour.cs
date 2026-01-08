using System;
using UnityEngine;

// ReSharper disable UselessBinaryOperation
// ReSharper disable ConditionIsAlwaysTrueOrFalse

[ExecuteInEditMode]
public class LessonOneTaskFour : MonoBehaviour
{
    public string taskOutput;
    public bool treasureRetrieved;
    
    // If statements are used to run conditional code, said condition is described in the contents of the '()' preceding the 'if' keyword.
    // The block following the statement, denoted using '{}', will only run if the condition is true.
    // This is where the importance of boolean values comes in.
    
    // Like with addition and subraction with integers and floats, boolean values can also have operators. 
    // The main ones you need to learn are:
    
    /*
        AND,    written as '&&',    when both conditions need to be true for the result to be true
        OR,     written as '||',    when either of the conditions need to be true for the result to be true
        NOT     written as '!',     this inverts the result.
    */
    
    // some examples of which are as follows:
    /*
       AND     true && true =>     true
               true && false =>    false
               false && true =>    false
               false && false =>   false
    
       AND     true || true =>      true
               true || false =>     true
               false || true =>     true
               false || false =>    false
               
       AND     !false =>            true
               !true =>             false
    */
    
    // if statements also can be preceded by both else, and elseif. These will only run if the if statement fails its condition.
    // 'else' will run the following block after the keyword
    // 'elseif' will only run the following block in the new condition is true -> 'elseif( condition2 )'
    
    // When numbers (ints or floats) are compared, you will use either:
    /*
        A == B,     A is the same as B
        A >  B,     A is greater than B
        A <  B,     A is less than B
        A >= B,     A is greater than or the same as B
        A <= B,     A is less than or the same as B
    */
    
    // Now that you understand variables and conditional statements a bit more lets explore them with a more thematic environment.
    // The below is a very basic example of what could be a level in a game.
    
    
    
    //       Player                     Snake,            Snake          ～°·_·°～        Weak Floor              Treasure Chest   //
    //         V                          V                V                 ^         Bottomless Pit                  V          //
    //       (^o^)丿                  ~>°)～～～        ~>°)～～～            Bat              V                       [=o=]        //
    ////////////////////////////////////////////////////////////////////////////////////#@#@#@#@#@#@//////////////////////////////// 
    //                                                                                //            //
    
    
    
    // Your job is to help the player collect the treasure by understanding if statements, follow the code below and open the claim the treasure to complete the task.
    
    public void Update()
    {
        // Read the if statements to understand the condition and how the code is changing, once you understand give the player the correct items.
        
        // !!! Change these values only !!!
        
        //////////////////////
        // PLAYER INVENTORY //
        //////////////////////
        
        int keys = 0;
        int swords = 0;
        int bows = 0;
        int arrows = 0;
        
        //////////////////////

        treasureRetrieved = false;
        int playerWeight = (swords * 10) + bows * 5 + arrows;

        // Fighting Snake 1
        if (swords == 0)
        {
            if (bows == 0 || arrows == 0)
            {
                taskOutput = "The player did not have a weapon to fight the snake, and died.";
                return; // <-- the return statement exits the function early - in this case no more of update will run.
            }
            else // <-- the else causes the following blocks to run only when the if statement fails.
            {
                arrows = arrows - 1;
            }
        }
        
        // Fighting Snake 2
        if (swords == 0)
        {
            if (bows == 0 || arrows == 0)
            {
                taskOutput = "The player did not have a weapon to fight the snake, and died.";
                return;
            }
            else
            {
                arrows = arrows - 1;
            }
        }
        
        // Fighting Bat
        if (bows == 0 || arrows == 0)
        {
            taskOutput = "The bat was out of reach of the player and attacked from a distance, without any ranged weapons left the player died.";
            return;
        }
        else
        {
            arrows = arrows - 1;
        }
        
        // Walking Over The Weak Ground
        if (playerWeight > 10)
        {
            taskOutput = "The player was too heavy, and the ground collapsed beneath them.";
            return;
        }
        
        // Opening The Chest
        if (keys == 0)
        {
            taskOutput = "The player did not have a key, the chest remained locked. They went home empty handed";
            return;
        }

        keys = keys - 1;
        
        treasureRetrieved = true;
    }
}
