using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPosition;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Dialogue"))
        {
            collider.GetComponent<PopupBox>().OpenBox();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Dialogue"))
        {
            collider.GetComponent<PopupBox>().CloseBox();
        }
    }
}
