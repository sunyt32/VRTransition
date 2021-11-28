using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountButton : MonoBehaviour
{
    public GameObject number;
    Counter counter;
    bool select;
    public void Click() {
        select = !select;
        if(select) {
            counter.count += 1;
        } else {
            counter.count -= 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        counter = number.GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
