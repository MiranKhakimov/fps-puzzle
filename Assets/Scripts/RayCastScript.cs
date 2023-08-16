using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    private Selectable currentSelectable;
    LayerMask mask;
    // Start is called before the first frame update
    private void Start()
    {
        mask = LayerMask.GetMask("TransparentFX");
        mask = ~mask;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward * 100);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, mask))
            {
                Selectable selectable = hit.collider.GetComponentInParent<Selectable>();
                if (selectable)
                {
                    if (currentSelectable == selectable)
                    {
                        currentSelectable.Deselect();
                        currentSelectable = null;
                    }
                    else
                    {
                        currentSelectable?.Deselect();
                        currentSelectable = selectable;
                    }

                    if (currentSelectable != null)
                    {
                        currentSelectable.Select();
                    }
                }
                else if (currentSelectable != null)
                {
                    var moveTo = currentSelectable.gameObject.GetComponent<MoveTo>();
                    if (moveTo != null)
                        Debug.Log(hit.point);
                        moveTo.SetTargetPos(hit.point);
                }
            }
        }
    }
}
