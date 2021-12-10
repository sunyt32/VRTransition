using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject scriptObject;

    Button button;
    Mobius script;
    // Start is called before the first frame update

    public void Click()
    {
        script.transition = true;
        button.enabled = false;
    }

    void Start()
    {
        script = scriptObject.GetComponent<Mobius>();
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
