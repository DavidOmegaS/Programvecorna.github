using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] float DashSpeed;
    bool IsDashing;
    newPlayerMovement nPL;
    // Start is called before the first frame update
    void Start()
    {
        IsDashing = false;
        nPL = GetComponent<newPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !IsDashing)
        {
            StartCoroutine(DashAbility());
        }
    }

    IEnumerator DashAbility()
    {
        IsDashing = true;
        nPL.moveSpeed += DashSpeed;
        yield return new WaitForSeconds(0.2f);
        nPL.moveSpeed -= DashSpeed;
        IsDashing = false;
    }
}
