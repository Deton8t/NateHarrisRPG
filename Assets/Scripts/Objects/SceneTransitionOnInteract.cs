using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneTransitionOnInteract : MonoBehaviour
{
    [SerializeField]
    private ChrMovementController playerInput;

    [SerializeField]
    private string scene;
    [SerializeField]
    private bool insideTrigger;
    void FixedUpdate()
    {
        if (!insideTrigger)
        {
            return;
        }
        if (Input.GetKey(playerInput.interact))
        {
            Transitioner.enterObject(scene);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!(col.gameObject.tag == "Player"))
        {
            return;
        }
        insideTrigger = true;
        playerInput = col.gameObject.GetComponent<ChrMovementController>();
    }
    void onTriggerExit2D(Collider2D col)
    {
        insideTrigger = false;
    }

}
