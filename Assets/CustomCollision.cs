using BulletSharp;
using BulletUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollision : BCollisionCallbacksDefault
{

    /// <summary>
    ///Beware of creating, destroying, adding or removing bullet objects inside CollisionEnter, CollisionStay and CollisionExit. Doing so can alter the list of collisions and ContactManifolds 
    ///that are being iteratated over
    ///(comodification). This can result in infinite loops, null pointer exceptions, out of sequence Enter,Stay,Exit, etc... A good way to handle this sitution is 
    ///to collect the information in these callbacks then override "OnFinishedVisitingManifolds" like:
    ///
    /// public override void OnFinishedVisitingManifolds(){
    ///     base.OnFinishedVistingManifolds(); //don't omit this it does the callbacks
    ///     do my Instantiation and deletion here.
    /// }
    /// </summary>

    bool kill = false;

    public override void BOnCollisionEnter(CollisionObject other, PersistentManifoldList manifoldList)
    {
        if(other.UserObject.ToString() == "Player (BulletUnity.BCharacterController)")
        {
            kill = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponScript>().AddAmmo();
        }
    }

    public override void OnFinishedVisitingManifolds()
    {
        base.OnFinishedVisitingManifolds();
        if (kill)
        {
            Destroy(gameObject);
        }
    }
}
