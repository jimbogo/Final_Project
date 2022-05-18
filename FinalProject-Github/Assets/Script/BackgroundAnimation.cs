using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    public Image img1;
    public Image img2;
    public Image img3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Anims());

        img1.enabled = true;
        img2.enabled = false;
        img3.enabled = false;
    }

    IEnumerator Anims(){

        img1.enabled = true;
        yield return new WaitForSeconds(2f);
        img2.enabled = true;
        img1.enabled = false;
        yield return new WaitForSeconds(0.01f);
        img2.enabled = false;
        img3.enabled = true;;
        yield return new WaitForSeconds(0.1f);
        img2.enabled = true;
        img3.enabled = false;
        yield return new WaitForSeconds(0.03f);
        img1.enabled = true;
        img2.enabled = false;
        yield return new WaitForSeconds(0.2f);
        img1.enabled = false;
        img2.enabled = true;;
        yield return new WaitForSeconds(0.01f);
        img2.enabled = false;
        img3.enabled = true;;
        yield return new WaitForSeconds(0.01f);
        img3.enabled = false;
        img1.enabled = true;;
        yield return new WaitForSeconds(1f);
        img1.enabled = false;
        img2.enabled = true;;
        yield return new WaitForSeconds(0.05f);
        img2.enabled = false;
        img1.enabled = true;;
        yield return new WaitForSeconds(0.01f);
        img2.enabled = false;
        img1.enabled = true;;
        yield return new WaitForSeconds(0.01f);
        img1.enabled = false;
        img2.enabled = true;;
        yield return new WaitForSeconds(0.02f);
        img2.enabled = false;
        img3.enabled = true;;
        yield return new WaitForSeconds(0.06f);
        img3.enabled = false;
        img1.enabled = true;;
        StartCoroutine(Anims());



    }
}
