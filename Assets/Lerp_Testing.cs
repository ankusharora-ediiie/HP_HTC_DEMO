using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp_Testing : MonoBehaviour
{
    public GameObject _startPosition;
    public GameObject _endPosition;
    public GameObject _endBeforePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_startPosition.transform.position!= _endPosition.transform.position)
        {
            _startPosition.transform.position = Vector3.Lerp(_startPosition.transform.position, _endPosition.transform.position, Time.deltaTime * 2f);
        }
        if(_startPosition.transform.position.z <= _endBeforePosition.transform.position.z)
        {
            Debug.Log("Reach to One Point");
        }
    }
}
