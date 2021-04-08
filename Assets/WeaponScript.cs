using BulletSharp;
using BulletUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] int ammo;
    [SerializeField] Camera cam;
    Canvas canvas;

    void Start()
    {
        canvas = Object.FindObjectOfType<Canvas>();
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo > 0 && Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            BulletSharp.Math.Vector3 fromP = ray.origin.ToBullet();
            BulletSharp.Math.Vector3 toP = (ray.direction*500).ToBullet();
            ClosestRayResultCallback callback = new ClosestRayResultCallback(ref fromP, ref toP);
            BPhysicsWorld world = BPhysicsWorld.Get();
            world.world.RayTest(fromP, toP, callback);
            if (callback.HasHit)
            {
                if(callback.CollisionObject.UserObject.GetType().Name == "BRigidBody")
                {
                    ((BRigidBody)callback.CollisionObject.UserObject).AddImpulse((new Vector3(callback.HitNormalWorld.X, callback.HitNormalWorld.Y, callback.HitNormalWorld.Z))*-5);
                }
            }

            ammo--;
            UpdateAmmo();
        }
    }

    public void AddAmmo()
    {
        ammo++;
        UpdateAmmo();
    }

    void UpdateAmmo()
    {
        canvas.GetComponentsInChildren<Text>()[2].text = "Ammo: " + ammo;
    }
}
