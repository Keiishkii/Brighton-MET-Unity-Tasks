using UnityEngine;

[ExecuteInEditMode]
public class LessonOneTaskOne : MonoBehaviour
{
    public bool taskCompleted = false;
    
    //  Comments are lines of code that do not affect the program.    
    //  There are a couple different ways to make a comment.
    //  The two main ways are using either '//' at the start of a line.
    
    /*
        Or '/'* and *'/' as shown here to create a block in which all
        text inside is considered as part of the comment.
        
        Comments can be used to describe code, or block some code from running.
        For example:     
    */
    
    // This is the Update function, we'll go more into what this does later.
    private void Update()
    {
        // The line below would output to the Unity console during play mode however since it is commented out, it will not run.  
        // Try uncommenting the line, you should see that 'LessonOneTaskOne Update' is printed in the console over and over.
        //Debug.Log("LessonOneTaskOne Update");
        
        // Finally, at the top of this file, is the line 'public bool taskCompleted = true;'
        // This is a boolean varaible (the next task will go into more detail on this).
        // Right now this is set to false, below commented out we can set it to true, uncomment this line out to complete the task.
        //taskCompleted = true;
    }
    
    // (Now that you know how to use comments, you can also comment back out the debug line, so it doesn't fill the console with any more messages)
}