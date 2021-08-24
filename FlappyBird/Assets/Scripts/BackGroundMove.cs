using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float speedMove;
    private float moveRanger;
    private Vector3 oldPosition;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        moveRanger = 14;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * speedMove, 0, 0));
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRanger)
        {
            obj.transform.position = oldPosition; // Set position begin
        }
    }
}
