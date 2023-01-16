using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D interactionCollider;

    public List<GameObject> interactables; 

    public void OnTriggerEnter2D(Collider2D collision)
    {
       //adds ajacent gameobjects to a list of interactables (checks if they are tagged as puzzles)
           GameObject gameObject = collision.gameObject;
            if (gameObject != null && gameObject.gameObject.tag == "Puzzle") 
            {
                Debug.Log(gameObject.name + " added");
                interactables.Add(gameObject); 
            }
           
     
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //removes objects that leave the players collision box from the list interactables
        GameObject gameObject = collision.gameObject;
        if (gameObject != null)
        {
            Debug.Log(gameObject.name + " removed");
            interactables.Remove(gameObject);
        }

    }

    public void Interact(InputAction.CallbackContext context)
    {   
        if (context.started) //called once when player interact button is pressed
        {
            Debug.Log("interact key pressed");
            interactPressed(); //calls interact pressed
        }
    }


    public void interactPressed()
    {
        Debug.Log("intertact activated");

        List<GameObject> interactablesUnique = interactables.Distinct().ToList(); //creates list without duplicates

        foreach (GameObject i in interactablesUnique) //loops through all adjacent game objects
        {
           I_interactable interactObject = i.gameObject.GetComponent<I_interactable>(); //check if they implement interactable interface
            if (interactObject != null) 
            {
                Debug.Log("attempting interact");
                interactObject.interact(); //call interact method if it is implemented
            }

        }
    }

}
