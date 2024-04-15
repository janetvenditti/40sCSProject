using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Exit;
    public GameObject Entrance;
    public Vector3 offsetExit = new Vector3(1, 0.5f, 0);
    public Vector3 offsetEnter = new Vector3(-1, 0.5f, 0);
    private Rigidbody2D body;

    [SerializeField] public SceneInfo sceneInfo;
    

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
            GameObject target = sceneInfo.isNextScene ? Entrance : Exit;
            Vector3 offset = sceneInfo.isNextScene ? offsetExit : offsetEnter;
        
        body.position = target.transform.position + offset;
    }

  
}
