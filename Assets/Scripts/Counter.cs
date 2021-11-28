using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int count;
    TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = count.ToString();
    }
}
