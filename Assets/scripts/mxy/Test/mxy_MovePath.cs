using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class mxy_MovePath : MonoBehaviour
{
    public Transform[] trPath;

    public Material matRed;

    public bool bIsMove;
	// Use this for initialization
	void Start ()
	{

	    transform.position = trPath[0].position;
	    MoveNext(1);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveNext(int iIndex)
    {
        if (bIsMove)
        {
            transform.DOMove(trPath[iIndex].position, 1).OnComplete(delegate
            {
                if (iIndex <= trPath.Length - 2)
                {
                    iIndex++;
                    MoveNext(iIndex);
                }
                else
                {
                    Destroy(GetComponent<TrailRenderer>());
                    transform.position = trPath[0].position;
                    transform.DOScale(Vector3.one, 0.5f).OnComplete(delegate
                    {

                        gameObject.AddComponent<TrailRenderer>();
                        gameObject.GetComponent<TrailRenderer>().time = Mathf.Infinity;
                        gameObject.GetComponent<TrailRenderer>().material = matRed;
                        MoveNext(1);
                    });
                }
            });
        }
        else
        {
            transform.GetComponent<TrailRenderer>().startWidth = 0.1f;
            transform.GetComponent<TrailRenderer>().endWidth = 0.1f;
            transform.DOMove(trPath[iIndex].position,0.01f).OnComplete(delegate
            {
                if (iIndex <= trPath.Length - 2)
                {
                    iIndex++;
                    MoveNext(iIndex);
                }
            });

        }
        
    }
}
