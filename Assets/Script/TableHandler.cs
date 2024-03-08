using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Chair[] chairs;
    public bool isFull = false;

    private void Start()
    {
        chairs = GetComponentsInChildren<Chair>();
    }

    public bool IsTableFull()
    {
        foreach (Chair chair in chairs)
        {
            if(!chair.occupied)
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        if (IsTableFull())
            isFull = true;
        else
            isFull = false;
    }



}
