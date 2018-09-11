using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPizza : MonoBehaviour
{
    [SerializeField]
    GameObject text;

    [SerializeField]
    GameObject text2;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                other.GetComponent<PlayerPizzaController>().pizza++;
                text.SetActive(false);
                text2.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        text.SetActive(false);
    }

}
