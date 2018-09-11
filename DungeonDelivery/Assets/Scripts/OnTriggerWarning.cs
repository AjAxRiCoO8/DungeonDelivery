using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerWarning : MonoBehaviour
{
    [SerializeField]
    GameObject textToDisplay;

    [SerializeField]
    GameObject camera;

    [SerializeField]
    float displacementAmount = 0.95f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerPizzaController pizzaManager = other.GetComponent<PlayerPizzaController>();
            if (pizzaManager.pizza < 1)
            {
                StartCoroutine(TellPlayerToPickPizza(other));
            }
        }
    }

    IEnumerator TellPlayerToPickPizza(Collider2D other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        textToDisplay.SetActive(true);
        other.GetComponent<PlayerMovement>().enabled = false;
        camera.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(3);
        other.GetComponent<PlayerMovement>().enabled = true;
        textToDisplay.SetActive(false);
        Destroy(this);
    }

}
