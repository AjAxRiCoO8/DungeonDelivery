using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _ChaseRadius;
    [SerializeField] private float _StoppingRadius;
    [SerializeField] private float _MoveSpeed;
	
	private void Update ()
    {
	    if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < _ChaseRadius &&
            Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) > _StoppingRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, _MoveSpeed * Time.deltaTime);
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _ChaseRadius);
    }
}
