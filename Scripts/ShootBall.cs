using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
using UnityEngine;



    public class ShootBall : MonoBehaviour
    {

    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;

        // Update is called once per frame
        void Update()
        {
        if (shoot_mode.shooting_mode == true)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
                shot.AddForce(shotPos.forward * shotForce);
            }
        }
    }
    }
