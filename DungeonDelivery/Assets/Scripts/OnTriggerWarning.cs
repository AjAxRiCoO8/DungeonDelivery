using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerWarning : MonoBehaviour
{
    GameObject textToDisplay;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
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
        textToDisplay.SetActive(true);
        other.GetComponent<PlayerMovement>().isActiveAndEnabled(false)
        yield return new WaitForSeconds(3);
    }

}
