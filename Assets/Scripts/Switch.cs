using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject scriptObject;
    public GameObject sphere;

    Transport script;
    RectTransform rectTransform;
    // Start is called before the first frame update

    public void Click()
    {
        script.transition = true;
        script.next = sphere;
    }

    void Start()
    {
        script = scriptObject.GetComponent<Transport>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = (script.last == sphere || script.transition) ? Vector3.zero : new Vector3(50, 50, 50);
    }
}
