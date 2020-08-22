using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluieCorru : MonoBehaviour
{
    [SerializeField] GameObject goutte;
    [SerializeField] Transform corru;
    private Vector3 newPos;
    
    bool spawner = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
        newPos = corru.transform.position + new Vector3(0, 1.3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner)
        {
            StartCoroutine("SpawnGoutte");
        }
    }

    IEnumerator SpawnGoutte()
    {
        Instantiate(goutte, newPos, Quaternion.identity, corru);
        //Instantiate(goutte, corru);
        spawner = false;
        yield return new WaitForSeconds(3f);
        spawner = true;
        StopCoroutine("SpawnGoutte");

    }
}
