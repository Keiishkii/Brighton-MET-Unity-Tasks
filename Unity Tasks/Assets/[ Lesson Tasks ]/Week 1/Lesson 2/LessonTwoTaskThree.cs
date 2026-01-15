using System;
using UnityEngine;

public class LessonTwoTaskThree : MonoBehaviour
{
    // So far we have done all our testing in the editor. 
    // Now we can start having a look at actually 'playing' a 'game'.
    // Components on game objects will always execute the following methods, though in which order they do them is very specific.
    // This is the Unity Execution Order.
    
    // The diagram on the link below will be incredbly helpful if you really dive into Unity and programming games. 
    // https://docs.unity3d.com/6000.0/Documentation/Manual/execution-order.html
    
    // For the most part though, just knowing the basics, 'Start', 'Update', and 'Fixed Update' should be good enough for now.
    

    ////////////////////////////////////
    //  Update-like: Event Functions  //
    ////////////////////////////////////
    
    // These functions run once, in response to a game objects change of state.
    
    // Awake runs when the object is first created and enabled in the scene.
    public void Awake()
    {
        
    }

    // Start runs once on the very first frame the object process an update.
    public void Start()
    {
        
    }
    
    // OnEnable runs everytime the object goes from being disabled to enabled
    public void OnEnable()
    {
        
    }

    // OnDisable runs everytime the object goes from being enabled to disabled
    public void OnDisable()
    {
        
    }

    // OnDestroy is called just before the object is destroyed (deleted from the game)
    public void OnDestroy()
    {
        
    }

    

    ///////////////////////////////////////
    //  Update-like: Built-in Functions  //
    ///////////////////////////////////////
    
    // These functions run constantly throughout the game while the object is enabled.

    // Update is called every frame, frames can have inconsistent display times (fps), but this is typically the same as the amount of visual frames the player sees.
    // This is primarily used for player inputs.
    public void Update()
    {
        
    }
    
    // LateUpdate is just like update, but occurs at the very end of the frame. Useful if you need specific behaviours to finish executing before you run some code.
    // This is most likely however one of the functions you will less likely use.
    public void LateUpdate()
    {
        
    }

    // Fixed update tries to keep a fixed amount of executions in a given time, if the fps slows down, fixed update will run multiple times to catch up.
    // This is primarily used for physics and collisions.
    public void FixedUpdate()
    {
        
    }
    
    // There isn't really a specific task with this, as that would go a bit to far into game logic (which I will cover in a future lesson).
    // For now though, try adding in some Debug.Log("") lines inside the different functions to see if you can get your head around the execution order.
    // Feel free to ask me any questions on when some of these might be useful!
}
