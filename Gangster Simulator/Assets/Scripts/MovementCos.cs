using UnityEngine;
using System.Collections;

public class MovementCos : MonoBehaviour {

    public Vector3 pointB;
    Vector3 pointA;

    void Start()
    {
      pointA = transform.position;
       
    }
    public void StartMove()
    {
        //while(transform.position != pointB)
        StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
    }
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        Debug.Log(transform.position);
        float i = 0.0f;
        float rate = 1.0f / time;
        while (transform.position != endPos)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(transform.position, endPos, i);
            yield return new WaitForSeconds(0.02f);
        }
        yield return true;
        //yield return new WaitForSeconds(2);
        Destroy(gameObject);
        // Debug.Log(transform.position);
    }

}
