using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FollowCam cam;
    public PlayerMovement heart;
    public PlayerMovement coin;

    void Start()
    {
        heart.active = true;
        coin.active = false;

        cam.target = heart.transform;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            heart.active = !heart.active;
            coin.active = !coin.active;

            if (heart.active)
            {
                cam.target = heart.transform;
            }
            else
            {
                cam.target = coin.transform;
            }
        }
    }
}
