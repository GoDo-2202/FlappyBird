using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speedMove;
    public float oldPosition;
    private float minY;
    private float maxY;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * speedMove, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EndPosition"))
        {
            Debug.Log("ResetWall");
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }      
    }
}
