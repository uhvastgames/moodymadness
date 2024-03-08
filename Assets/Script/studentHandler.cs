using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class studentHandler : MonoBehaviour
{

    public float sitDuration;
    public float speed;
    private GameObject[] tables;
    private Transform target;
    public bool inChair  = false;
    public float timeSitting = 0;

    // Start is called before the first frame update
    void Start()
    {
        sitDuration = Random.Range(5, 12);
        tables = GameObject.FindGameObjectsWithTag("table");
    }

    // Update is called once per frame
    void Update()
    {
        if (target==null || Vector3.Distance(transform.position, target.position)<0.01f)
        {
            GameObject nearestTable = FindNearestTable();
            if(nearestTable!=null)
            {
                //find unoccupied chair
                TableHandler table = GetComponent<TableHandler>();
                //if(!table.isFull)
                {
                    Transform unoccupiedChair = FindUnoccupiedChair(nearestTable);
                    if (unoccupiedChair != null)
                    {
                        target = unoccupiedChair; //move towards it
                    }
                    else
                    {
                        target = nearestTable.transform;
                    }
                }
            }
            else
            {
                MoveRandomly();
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

        if (inChair && timeSitting<sitDuration)
        {
            timeSitting+= Time.deltaTime;
            speed = 0f;
        }
        else if(inChair && timeSitting>sitDuration)
        {
            gameObject.SetActive(false);
        }
        else
        {
            //nothing to see here, move along
        }
    }

    GameObject FindNearestTable()
    {
        GameObject nearestTable = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject table in tables)
        {
            TableHandler tableScript = table.GetComponent<TableHandler>();
            if (tableScript != null && !tableScript.IsTableFull())
            {
                float distance = Vector3.Distance(transform.position, table.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestTable = table;
                }
            }
        }

        return nearestTable;
    }

    Transform FindUnoccupiedChair(GameObject table)
    {
        TableHandler tableScript = table.GetComponent<TableHandler>();
        if (tableScript != null)
        {
            Chair[] chairs = table.GetComponentsInChildren<Chair>();
            foreach (Chair chair in chairs)
            {
                if (!chair.occupied)
                {
                    return chair.transform;
                }
            }
        }
        return null;
    }

    void MoveRandomly()
    {
        // Logic to move NPC randomly if no tables are available
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chair"))
        {
            inChair = true;
            Debug.Log("fla pla pla plah!");
            Chair chair = collision.GetComponent<Chair>();
            chair.occupied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("chair"))
        {
            inChair = false;
            Chair chair = collision.GetComponent<Chair>();
            chair.occupied = false;
        }
    }
}
