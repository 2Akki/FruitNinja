using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float minVelo = 0.1f;
    private Vector3 lastMousePos;
    private Vector3 mousevElo;
    private Collider2D mousecol;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mousecol= GetComponent<Collider2D>();
        
    }
    private void Update()
    {
       
        SetbladeToMouse();

        
    }

    private void SetbladeToMouse() {
        var mousepos = Input.mousePosition;
        mousepos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousepos);


    }
    private void FixedUpdate()
    {
        Vector3 curMousePos = transform.position;
        float travled = (lastMousePos - curMousePos).magnitude;

        print((lastMousePos - curMousePos).magnitude);
        lastMousePos = curMousePos;


        if (travled > minVelo)
        {
            mousecol.enabled = true;
        }
        else
        {
            mousecol.enabled = false;
        }
    }
   
}
