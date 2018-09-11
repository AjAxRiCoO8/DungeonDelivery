using System.Collections;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _SpeechBubble;
    [SerializeField] private GameObject _SpeechBubble2;
    [SerializeField] private GameObject _Camera;

    private bool _GotPizzaDelivered;

    private void Start()
    {
        _GotPizzaDelivered = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_GotPizzaDelivered)
            {
                _GotPizzaDelivered = true;
                StartCoroutine(ShowMessage(collision));
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerPizzaController ppc = collision.GetComponent<PlayerPizzaController>();

                if (ppc.pizza == 1)
                {
                    ppc.pizza--;
                    _SpeechBubble2.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _SpeechBubble2.SetActive(false);
    }

    private IEnumerator ShowMessage(Collider2D collision)
    {
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();

        _SpeechBubble.SetActive(true);

        _Camera.GetComponent<Animation>().Play();

        pm.enabled = false;

        yield return new WaitForSeconds(3);

        pm.enabled = true;

        _SpeechBubble.SetActive(false);
    }
}
