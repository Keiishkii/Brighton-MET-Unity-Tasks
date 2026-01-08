using System;
using UnityEngine;

[ExecuteInEditMode]
public class LessonOneTaskTwo : MonoBehaviour
{
    // Some languages let a variable be anything, however C# is what's called a strongly typed language and requires variables to have specific 'types'.
    
    // In C# there are a fair few basic variable types you can use:
    // int, long, short, byte, float, double, decimal, bool, char, struct, enum, string, etc...
    
    // For our purposes though, we will only look into the most commonly used ones. These being:
    
    // string:  any kind of text, denoted using double quotation marks.         For example - string name = "Charlie!";     <- strings must be contained within "quotations"
    // int:  an integer number (without a decimal place).                       For example - int classNumber = 601;
    // float:  a number with decimal places.                                    For example - float pi = 3.14159f;          <- floats must end with the suffix 'f'.
    // bool:  this type just describes is something is true or false.           For example - bool isPlayerAlive = true;    <- booleans can only be true or false

    // using the variables below, without changing their names, try setting them to something else in the Update function. You should be able to see these changes appear in the unity inspector for Task 2.
    // Once all are set to something new the task should be complete!
    // IMPORTANT -> This must be done in the Update function as Unity serialises public fields so they can be modified in the editor. (Which I have currently hidden for now) 
    
    public string text;
    public int integerNumber;
    public float rationalNumber;
    public bool boolean;
    
    // Like before you can also view the usage your variables during playmode in the editor by printing them to the Unity console.
    // comment out the debug log and change what variable is being written.
    public void Update()
    {
        //Debug.Log(text);
    }
}
