using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobius : MonoBehaviour
{
    public GameObject next;
    public GameObject last;
    public bool transition;

    int time;
    Transform nextPosi;
    Transform lastPosi;
    Vector3 distance;
    Vector3 scale;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        nextPosi = next.GetComponent<Transform>();
        lastPosi = last.GetComponent<Transform>();
        //nextPosi.localScale = Vector3.zero;
        count = 0;
        distance = nextPosi.position - lastPosi.position;
        time = 120;
        scale = lastPosi.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!transition)
        {
            return;
        }
        if(count < time)
        {
            nextPosi.localScale = scale * (0.38f * count / time);
        }
        else if (count < time * 2)
        {
            nextPosi.position -= distance / time;
            lastPosi.position -= distance / time;
            nextPosi.localScale = scale * (0.38f + 0.62f * (count - time) / time);
            lastPosi.localScale = scale * (0.38f + 0.62f * (time + time - count) / time);
        }
        else if (count < time * 3)
        {
            lastPosi.localScale = scale * (0.38f * (time + time + time - count) / time);
        } else
        {
            transition = false;
        }
        count++;
    }
}
