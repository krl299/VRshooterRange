using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWeaponSystem : MonoBehaviour
{
    public GameObject bullet;
    public GameObject controller;
    public float shootForce;
    public Transform shootPoint;

    void Update()
    {
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
            controller.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Instantiate(bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(-shootPoint.forward * shootForce);

                }
            }
        }
        else
        {
            controller.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        }
    }
}   
