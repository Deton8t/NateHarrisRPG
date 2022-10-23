using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Vector3 direction;
    public enemyHit hitDetector;
    private GameObject player;
    [SerializeField]
    private Vector2 rayCastDirection;
    [SerializeField]
    private float rayCastDistance;
    LayerMask playerLayer;
    [SerializeField]
    private bool isInRange;
    private bool[] canCheckStateChange = new bool[] { false, false, false, false, false, false, false, false, false, false };
    private int[] states = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        hitDetector = this.GetComponent<enemyHit>();
        // If I want to expand this game to multiplayer 
        //I would have to make player an array
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        rayCastDirection = findDirection();
        if (!isInRange)
        {
            return;
        }
        RaycastHit2D meleeProximityRay = Physics2D.Raycast(this.gameObject.transform.position, rayCastDirection, rayCastDistance, playerLayer.value);
        Debug.DrawRay(this.gameObject.transform.position, rayCastDirection * new Vector2(rayCastDistance, rayCastDistance), Color.red, .05f);
        if (hitDetector.inHitStun)
        {
            return;
        }
        Debug.Log(meleeProximityRay.collider);
        if (meleeProximityRay.collider != null)
        {
            canCheckStateChange[0] = true;
            stateChangeRNG(4, .3f, 0);
            Debug.Log("I have hit the player");
        }
    }

    private Vector2 findDirection()
    {
        Vector2 differenceFromPlayer = (player.transform.position - this.gameObject.transform.position);
        isInRange = inRange(differenceFromPlayer.x, differenceFromPlayer.y);
        differenceFromPlayer.Normalize();
        return (differenceFromPlayer);
    }

    private bool inRange(float distanceX, float distanceY)
    {
        if (Mathf.Abs(distanceX) > 7 || Mathf.Abs(distanceY) > 7)
        {
            return (false);
        }
        return (true);
    }
    private void stateChangeRNG(int rngRange, float checkTimer, int state)
    {
        if (!canCheckStateChange[state])
        {
            return;
        }
        if ((int)Random.Range(0, rngRange) == 1)
        {
            //Update state machine here
        }
        delay(checkTimer, state);
    }
    private IEnumerator delay(float waitTime, int state)
    {
        canCheckStateChange[state] = false;
        yield return new WaitForSeconds(waitTime);
        canCheckStateChange[state] = true;
    }
}
