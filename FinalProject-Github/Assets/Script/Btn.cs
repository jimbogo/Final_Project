using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public Camera cam;

    void Update(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            Debug.Log("hit");
            hit.collider.GetComponent<Text>().text = "<color=red>Settings</color>";
        }
    }
}
