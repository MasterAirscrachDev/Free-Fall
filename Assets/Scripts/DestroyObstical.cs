using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstical : MonoBehaviour
{
    Transform player;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        //get the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is above the obstical then become active
        if (player.position.y > transform.position.y)
        { active = true; }
        //if we are above the player then destroy us
        if (transform.position.y > player.position.y && active)
        { Destroy(gameObject); }
    }
}
