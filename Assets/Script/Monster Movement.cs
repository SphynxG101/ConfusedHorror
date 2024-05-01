using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 position;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
        while (Vector3.Distance(pos, position) < 30)
        {
            position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        int keycount = PlayerPrefs.GetInt("KeyCount", 0);
        pos = player.transform.position;
        position = transform.position;
        //position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
        
        if (keycount == 0)
        {
            while (Vector3.Distance(pos, position) < 7.5f || Vector3.Distance(pos, position) > 50)
            {
                position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
            }
        }
        else if (keycount == 1)
        {
            while (Vector3.Distance(pos, position) < 7.5f || Vector3.Distance(pos, position) > 40)
            {
                position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
            }
        }
        else if (keycount == 2)
        {
            while (Vector3.Distance(pos, position) < 7.5f || Vector3.Distance(pos, position) > 30)
            {
                position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
            }
        }
        else if (keycount == 3)
        {
            while (Vector3.Distance(pos, position) < 7.5f || Vector3.Distance(pos, position) > 25)
            {
                position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
            }
        }
        else if (keycount == 4)
        {
            while (Vector3.Distance(pos, position) < 7.5f || Vector3.Distance(pos, position) > 20)
            {
                position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
            }
        }
        else if (keycount == 5)
        {
            while (Vector3.Distance(pos, position) < 7.5f || Vector3.Distance(pos, position) > 15)
            {
                position = transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 2, Random.Range(-53f, 42f));
            }
        }
        
        transform.position = position;
    }
}
