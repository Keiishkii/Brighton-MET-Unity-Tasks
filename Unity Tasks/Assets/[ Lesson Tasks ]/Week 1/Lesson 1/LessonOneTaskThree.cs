using System;
using UnityEngine;

[ExecuteInEditMode]
public class LessonOneTaskThree : MonoBehaviour
{
    public string taskOutput;

    public int integerInputOne;
    public int integerInputTwo;
    public int integerOutput;
    public string stringInputOne;
    public string stringInputTwo;
    public string stringOutput;
    
    
    
    // In this task you will have a play around with manipulating different variables. 
    // Numeric variables like ints and floats can be treated like any number so adding subtracting multiplying and division are all possible.
    // (Just keep in mind with division that an integer will always return an integer so 5 / 2, will equal 2 not 2.5).

    
    public void Update()
    {
        int a = 5;
        int b = 10;
        int c = a + b; // <-- In this case, c will equal 15, given we are adding both a and b together.
        
        // Variables can also be used to set themselves too, as strange as this looks this will work.
        c = c + 10;
        
        // Most variables can also be "casted" this is where we try to convert a type to another.
        // This can be helpful if we need to either output a value to the console (as a string), or to get a decimal value from two integer divisions.

        int d = 5;
        int e = 2;
        
        float f = d / e; // <-- this will output 2, as the decimal value is truncated off.
        float g = d / (float)e; // <-- this will equal 2.5, as c# knows to keep the decimal part if one of the numbers is a float type.
        
        // You can see this kind of change using either a debug log to write the output to the console, or by replacing the taskOutput variable with one of these values.
        // This will automatically convert the floats to a string to be written to the console, or the inspector.
        

        
        string first = "Hello ";
        string second = "World";

        // Strings can also be added together using the + operator, however instead of adding in the same way a number would, instead they will be appended.
        // Have a look at the output of the following varaibles using the log or taskOutput variable.
        
        string combined = first + second;


        // To complete this task correctly finish the assignment of the following variables.

        
        // Try and get the values of intergetOutput to equal the value of [ integerInputOne and integerInputTwo ] without just typing in the answer as a number.
        integerInputOne = 17;
        integerInputTwo = 32;
        
        integerOutput = 0;
        
        
        // Try to get the value of stringOutput to equal the combined string of [ stringInputOne and stringInputTwo ] without just typing in the answer as a phrase.
        stringInputOne = "Brighton";
        stringInputTwo = "MET";
        
        stringOutput = "";
    }
}
