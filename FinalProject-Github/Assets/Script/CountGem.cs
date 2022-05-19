using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountGem : MonoBehaviour
{
    public static Text count;
    public static float num =0;
    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
