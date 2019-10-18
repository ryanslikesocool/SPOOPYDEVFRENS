using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bopper : MonoBehaviour
{
    private Vector3 initialScale;
    //private Vector3 initialPosition;
    [SerializeField]
    private Vector3 deltaScale = Vector3.up * 0.5f;
    [SerializeField]
    private bool bopping = false;

    void Start()
    {
        initialScale = transform.localScale;
        //initialPosition = transform.localPosition;

        Conductor.instance.beatEvent.AddListener(Bop);
    }

    void Bop()
    {
        if (bopping)
        {
            transform.localScale = initialScale + deltaScale;
            //transform.localPosition = initialPosition + deltaScale * 0.25f;
        }
        else
        {
            transform.localScale = initialScale;
            //transform.localPosition = initialPosition;
        }

        bopping = !bopping;
    }
}