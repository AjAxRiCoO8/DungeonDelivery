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
        other.GetComponent<Animator>().Play("ForgetPizzaScene");
        yield return new WaitForSeconds(3);

        other.transform.localScale = new Vector2(Mathf.Abs(other.transform.localScale.x), other.transform.localScale.y);

        float timer = 0;
        float duration = 0.4f;

        Debug.Log("1");

        while (timer <= duration)
        {
            other.transform.position = new Vector2(other.transform.position.x - 0.4f * Time.deltaTime, other.transform.position.y);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        /*
        float timer = 0.001f;
        float totalDuration = 5;
        float startPosX = other.transform.position.x;
        float goalPosX = other.transform.position.x - 0.2f;
        while (timer <= totalDuration)
        {
            float lerp = Mathf.Lerp(startPosX, goalPosX, timer / totalDuration);
            timer += Time.deltaTime;
            other.transform.position = new Vector2(lerp, other.transform.position.y);
        }
        */

        other.GetComponent<PlayerMovement>().enabled = true;
        textToDisplay.SetActive(false);
        //Destroy(this);
    }

}
