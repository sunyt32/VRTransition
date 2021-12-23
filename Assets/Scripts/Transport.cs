using UnityEngine;


public class Transport : MonoBehaviour
{
    public GameObject VRCarema;
    public GameObject room;
    public GameObject next;
    public GameObject last;
    public bool transition;

    int time;
    Transform nextPosi, lastPosi, cameraPosi, roomPosi;
    Material lastMaterial, nextMaterial;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        cameraPosi = VRCarema.GetComponent<Transform>();
        roomPosi = room.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!transition)
        {
            return;
        }
        if (time == 0)
        {
            nextPosi = next.GetComponent<Transform>();
            lastPosi = last.GetComponent<Transform>();
            nextPosi.localScale = 10 * Vector3.one;
            roomPosi.localScale = 10 * Vector3.one;
            distance = nextPosi.position - lastPosi.position;
            lastMaterial = last.GetComponent<MeshRenderer>().material;
            nextMaterial = next.GetComponent<MeshRenderer>().material;
        }
        if (time <= 60)
        {
            lastMaterial.SetFloat("_Alpha", 1 - (float)time / 60);
        }
        else if (time <= 260)
        {
            cameraPosi.position += distance / 200;
        }
        else if(time <= 320)
        {
            nextMaterial.SetFloat("_Alpha", (float)(time - 260) / 60);
        }
        if (time == 320)
        {
            last = next;
            time = 0;
            lastPosi.localScale = Vector3.zero;
            roomPosi.localScale = Vector3.zero;
            transition = false;
            return;
        }
        time++;
    }
}
