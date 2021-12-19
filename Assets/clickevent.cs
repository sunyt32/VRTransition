using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class clickevent : MonoBehaviour 
{
    public GameObject camera;
    public GameObject sphere;
    private Transform cameraposi;
    private Transform sphereposi;
    private Vector3 derta;
    private int time;
    public bool select;
    public void OnSubmit()
    {
        select = true;
        time = 0;
    }
    void Start()
    {
        select = false;
        cameraposi = camera.GetComponent<Transform>();
        sphereposi = sphere.GetComponent<Transform>();
        
    }
    void Update()
    {
        if(select){
            if(time == 0){
                derta = sphereposi.position - cameraposi.position;
                derta.y = 0f;
            }
            if(time < 200){
                cameraposi.position += derta*0.005f;
                time+=1;
            }
            else if(time == 200){
                sphereposi.localScale = Vector3.zero;
                select = false;
            }
        }
        if(cameraposi.position.x!=sphereposi.position.x&&time!=200){
            sphereposi.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    }   
}