using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bio" || target.tag == "nonbio" || target.tag == "recyclable")
        {
            target.gameObject.SetActive(false);
        }
    }
}
