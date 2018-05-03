using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mxy_CameraRay : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MeshRenderer>() == null)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("mxy_Building") && !other.name.Equals(mxy_SelectBuilding.goCurrentNormalBuilding.goNormal.name))
        {
            if (other.GetComponent<MeshRenderer>() == null)
            {
                other.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                other.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("mxy_Building") && !other.name.Equals(mxy_SelectBuilding.goCurrentNormalBuilding.name))
        {
            if (other.GetComponent<MeshRenderer>() == null)
            {
                other.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                other.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }




}
