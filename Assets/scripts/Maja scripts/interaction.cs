using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script anv�nds inte
interface IInteractable
{
    public void Interact();
}

public class interaction : MonoBehaviour
{
    public Transform InteractorSource;

    public float InteractRange;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }

        }
    }
}
