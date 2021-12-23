using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class clickevent : MonoBehaviour 
{
    public GameObject sphere;
    public GameObject scriptObject;

    Transport script;
    RectTransform rectTransform;
    Vector3 position;
    public void OnSubmit()
    {
        script.transition = true;
        script.next = sphere;
    }
    void Start()
    {
        script = scriptObject.GetComponent<Transport>();
        rectTransform = GetComponent<RectTransform>();
        position = rectTransform.localPosition;
    }
    void Update()
    {
        Vector3 cameraPosi = script.last.GetComponent<Transform>().localPosition;
        rectTransform.localPosition = (position - cameraPosi).normalized * 5 + cameraPosi;
        rectTransform.localScale = (script.last == sphere || script.transition) ? Vector3.zero : new Vector3(0.5f, 0.5f, 0.5f);
    }   
}