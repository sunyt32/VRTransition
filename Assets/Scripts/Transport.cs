using UnityEngine;


public class Transport : MonoBehaviour
{
    public GameObject VRCarema;
    public GameObject next;
    public GameObject last;
    public bool transition;
    public bool teleport;
    public bool mobius;

    int time, count, transportTime;
    Transform nextPosi;
    Transform lastPosi;
    Transform caremaPosi;
    Material material;
    Vector3 previous;
    Vector3 distance;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time = 120;
        transportTime = 45;
        caremaPosi = VRCarema.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Teleport()
    {
        nextPosi = next.GetComponent<Transform>();
        lastPosi = last.GetComponent<Transform>();
        caremaPosi.position = nextPosi.position;
        nextPosi.localScale = lastPosi.localScale;
        lastPosi.localScale = Vector3.zero;
        transition = false;
        last = next;
    }
    void Mobius()
    {
        if (count == 0)
        {
            nextPosi = next.GetComponent<Transform>();
            lastPosi = last.GetComponent<Transform>();
            distance = nextPosi.position - lastPosi.position;
            scale = lastPosi.localScale.x;
        }
        if (count <= time)
        {
            nextPosi.localScale = (0.5f * count / time) * distance.magnitude * Vector3.one;
        }
        else if (count <= time + transportTime)
        {
            caremaPosi.position += distance / transportTime;
        }
        else if (count <= time * 2 + transportTime)
        {
            nextPosi.localScale = scale * Vector3.one;
            lastPosi.localScale = 0.5f * (time * 2 + transportTime - count) / time * distance.magnitude * Vector3.one;
        }
        else
        {
            transition = false;
            last = next;
            count = 0;
            return;
        }
        count++;
    }
    void Gradual()
    {
        last.GetComponent<MeshRenderer>().material.renderQueue = 3200;
        next.GetComponent<MeshRenderer>().material.renderQueue = 3000;
        if (count == 0)
        {
            nextPosi = next.GetComponent<Transform>();
            lastPosi = last.GetComponent<Transform>();
            caremaPosi.position = nextPosi.position;
            nextPosi.localScale = new Vector3(1200, 1200, 1200);
            lastPosi.localScale = new Vector3(500, 500, 500);
            previous = lastPosi.position;
            lastPosi.position = nextPosi.position;
            material = last.GetComponent<MeshRenderer>().material;
        }
        else if (count <= time)
        {
            material.SetFloat("_Alpha", 1 - (float)count / time);
        }
        else
        {
            material.SetFloat("_Alpha", 1);
            lastPosi.position = previous;
            lastPosi.localScale = Vector3.zero;
            transition = false;
            last = next;
            count = 0;
            return;
        }
        count++;
    }
    void Update()
    {
        if (!transition)
        {
            return;
        }
        if (teleport)
        {
            Teleport();
        } else if (mobius)
        {
            Mobius();
        } else
        {
            Gradual();
        }
        
    }
}
