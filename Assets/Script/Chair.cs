using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    // Start is called before the first frame update
    public bool occupied = false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //put box collider logic for character and chair. 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("student"))
        {
            occupied = true;
            studentHandler student = other.GetComponent<studentHandler>();
            if (student != null)
            {
                student.inChair = true;
                
            }
            
        }

    }


}
