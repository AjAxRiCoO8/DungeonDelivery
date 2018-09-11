using System.Collections;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _SpeechBubble;
    private bool _GotPizzaDelivered;

    private void Start()
    {
        _GotPizzaDelivered = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && !_GotPizzaDelivered)
        {
            _GotPizzaDelivered = true;
            StartCoroutine(ShowMessage());
        }
    }

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(3);
    }
}
