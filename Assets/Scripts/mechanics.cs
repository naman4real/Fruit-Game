using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechanics : MonoBehaviour
{
    
    public float flag = 0;
    public bool playPluck = false;
    public List<GameObject> stones;


    private bool move = false;
    private int count = 0;
    private int fruitCount = 0;
    private int dropFlag = 0;
    private GameObject obj;    
    private ParabolaController cont;
    private OSC oscScript;
    private GameObject oscGameObject;
    private OscMessage message;
    private Vector3 originalObjPosition;
    [SerializeField] private float speed = 3f;
    [SerializeField] private List<GameObject> fru;
    [SerializeField] private List<Material> sky;
    private void Awake()
    {
        RenderSettings.skybox = sky[Random.Range(0, sky.Count)];
    }
    void Start()
    {
        //UnityEngine.XR.InputTracking.disablePositionalTracking = true;
        oscGameObject = GameObject.Find("OSC");
        oscScript = oscGameObject.GetComponent<OSC>();
        oscScript.SetAddressHandler("/Spirometer/C", BreathData);
        
    }


    void BreathData(OscMessage message)
    {
        float breath_value = message.GetFloat(0);
        Debug.Log(breath_value + " breath");
        if (breath_value>=2600)
        {
            flag = 1;
        }
        else if (breath_value <2600 && breath_value>=1300)
        {
            flag = 2;
        }
        else
        {
            flag = 3;
        }
    }



    void Update()
    {
        OVRInput.Update();
        // inhale the stone
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || flag==1)
        {
            if (count == stones.Count)
            {
                Debug.Log("No more stones left");   
            }
            else 
            {
                obj = stones[count];
                originalObjPosition = obj.transform.position;
                cont = GameObject.Find(obj.name).GetComponent<ParabolaController>();
                Debug.Log(stones[count].gameObject.name);
                move = true;

            }

        }
        if (move /*&& flag==1*/)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, this.transform.position, Time.deltaTime * speed);
            //dropFlag = 1;

        }
        /*
        else if(obj && dropFlag==1 && flag!=1 && Vector3.Distance(obj.transform.position, transform.position) > 0.2f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, originalObjPosition, Time.deltaTime * speed);
            obj.GetComponent<Rigidbody>().useGravity = true;
            move = false;
            count++;
            dropFlag = 0;
            Debug.Log("count" + count);
            
        }
        */
        //if (obj && Vector3.Distance(obj.transform.position, transform.position) <= 0.1f)
        //{
        //    dropFlag = 0;
        //}
        // When the stone has arrived near the player
        if((Input.GetKeyDown(KeyCode.D) || OVRInput.Get(OVRInput.RawButton.A) || flag==3)  && Vector3.Distance(obj.transform.position, transform.position)<0.1f && fruitCount<fru.Count)
        {
            move = false;
            Debug.Log("Can Shoot");
            GameObject point1 = new GameObject();
            GameObject point2 = new GameObject();
            GameObject point3 = new GameObject();
            GameObject root = new GameObject();
            point1.name = "child1";
            point2.name = "child2";
            point3.name = "child3";
            root.name = "parent";
            point1.transform.parent = root.transform;
            point2.transform.parent = root.transform;
            point3.transform.parent = root.transform;
            point1.transform.position = transform.position;
            point3.transform.position = fru[fruitCount].transform.position;
            point2.transform.position=new Vector3((point1.transform.position.x+point3.transform.position.x)/2,point3.transform.position.y+0.3f, (point1.transform.position.z + point3.transform.position.z) /2);
            
            cont.ParabolaRoot = root;
            cont.Speed = 7f;
            cont.Autostart = true;
            cont.Animation = true;
            if (!cont.enabled)
            {
                cont.enabled = true;
            }

        }//When the stone has hit the  fruit
        if (obj && Vector3.Distance(obj.transform.position, fru[fruitCount].transform.position) < 1f && fruitCount<fru.Count)
        {
            Destroy(obj);
            playPluck = true;
            count++;
            fru[fruitCount].GetComponent<Rigidbody>().useGravity = true;
            //fru[fruitCount].GetComponent<Rigidbody>().isKinematic = true;
            fruitCount++;

        }




    }



}
