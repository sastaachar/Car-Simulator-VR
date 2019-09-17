using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Restrict : MonoBehaviour {

    public float x;
    float y, z;
      
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(transform.eulerAngles.x + " - " + transform.eulerAngles.y + " - " + transform.eulerAngles.z);


        OVRGrabbable sn = gameObject.GetComponent<OVRGrabbable>();

        if (!sn.isGrabbed)
        {
            transform.eulerAngles = new Vector3(x, 180, 180);
        }
        else
        {
            if (sn.getName.name.ToString() == "CustomHandLeft")
            {
                y = 270;
                z = 90;
            }
            else
            {
                y = 90;
                z = 270;
            }
        }
        

        if (transform.eulerAngles.y != y || transform.eulerAngles.z != z)
        {
                
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, z);
                

        }

      
      
    }
}
