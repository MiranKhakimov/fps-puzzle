using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed = 5f;
    private Vector3 targetPosition;
    private Vector3 areaCenter;
    private float rangeOfMovement;
    private float bignumber;
    public GameObject areaOfMovement;

    public void SetTargetPos(Vector3 pos)
    {
        targetPosition = pos;
        Debug.Log(areaOfMovement.GetComponent<SphereCollider>().radius);
        Debug.Log(rangeOfMovement);

    }

    private void Start()
    {
        bignumber = areaOfMovement.GetComponent<SphereCollider>().radius * areaOfMovement.transform.localScale.x;
        targetPosition = transform.position;
        rangeOfMovement = bignumber;
        areaCenter = areaOfMovement.transform.position;
    }

    private void FixedUpdate()
    {
        float distToCenterFromTargetPos = (areaCenter - targetPosition).magnitude;
        float distanceToCenter = (areaCenter - transform.position).magnitude;
        if ((targetPosition - transform.position).magnitude < 0.1f || distanceToCenter >= rangeOfMovement)
        {
            body.velocity = Vector3.zero;
            if (distToCenterFromTargetPos <= rangeOfMovement)
            {
                var direction = (targetPosition - transform.position).normalized;
                body.velocity = direction * speed;
            }
        }
        else
        {
            var direction = (targetPosition - transform.position).normalized;
            body.velocity = direction * speed;
        }
    }
}
