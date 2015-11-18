using UnityEngine;
using System.Collections;

public class ScrollingManager : MonoBehaviour {

    public float speed;
    public bool clone;
    public bool destroy;
    public float DistanceFromCameraToClone;
    public string prefabPath;//"Prefabs/Background/XXXXXX"
    public string prefabPathSup;//"Prefabs/Background/XXXXXX"
    public string prefabPathSup2;//"Prefabs/Background/XXXXXX"
    public float XSize;
    public float DistanceFromCameraToDestroy;
    public int nbPrefab;

    private Transform myTransform;
    private Vector3 direction;
    private GameObject prefabToClone;
    private GameObject prefabToCloneBis;
    private GameObject prefabToCloneBis2;
    private Transform camTransform;
    //private LevelManager levelManager;
    //private GameObject dynamicHierarchy;

    // Use this for initialization
    void Start()
    {
        if (clone)
        {
            prefabToClone = Resources.Load(prefabPath) as GameObject;
            if (prefabPathSup.Length > 5)
            {
                prefabToCloneBis = Resources.Load(prefabPathSup) as GameObject;
                prefabToCloneBis2 = Resources.Load(prefabPathSup2) as GameObject;
            }
            camTransform = GameObject.Find("Main Camera").GetComponent<Transform>();

            //levelManager = LevelManager.GetInstance();
            //dynamicHierarchy = GameObject.Find("DYNAMIC") as GameObject;
        }

        myTransform = this.transform;
        direction = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = speed * Time.deltaTime;
        myTransform.Translate(direction * amountToMove);

        if (clone && DistanceFromCameraToClone <= camTransform.position.x - myTransform.position.x)
        {
            Vector3 deplacement = new Vector3(XSize, 0, 0);

            if (prefabToCloneBis == null)
                Instantiate(prefabToClone, myTransform.position + deplacement, myTransform.rotation);
            else
            {
                int rand = Random.Range(0, nbPrefab);
                if (rand == 0)
                    Instantiate(prefabToClone, myTransform.position + deplacement, myTransform.rotation);
                else if(rand == 1)
                    Instantiate(prefabToCloneBis, myTransform.position + deplacement, myTransform.rotation);
                else
                    Instantiate(prefabToCloneBis2, myTransform.position + deplacement, myTransform.rotation);
            }
            //GameObject newBackground = Instantiate(prefabToClone, myTransform.position + deplacement, myTransform.rotation) as GameObject;
            //newBackground.transform.parent = dynamicHierarchy.transform;
            //Renderer rendTemp = newBackground.GetComponent<Renderer>();
            //levelManager.GetRendererList().Add(rendTemp);

            clone = false;
        }

        if (destroy && DistanceFromCameraToDestroy <= (camTransform.position.x - myTransform.position.x))
        {
            //Debug.Log("Destroy :  " + DistanceFromCameraToDestroy + "<=" + (camTransform.position.x - myTransform.position.x));
            Destroy(this.gameObject);
        }
    }
}
