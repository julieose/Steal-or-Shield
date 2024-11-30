using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ClickControl1 : MonoBehaviour
{
    public static string obj_name;
    public GameObject obj_txt;
    public ItemCounter itemCounter;// —сылка на объект ItemCounter
    public Transform MyPartSys;
    //Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Instantiate(MyPartSys, gameObject.transform.position, MyPartSys.rotation);
        ClickTrack.TotalClick = 0;
        //Link the object and the text
        obj_name = gameObject.name;
        //Debug.Log (obj_name);
        //Destroy the object and the text
        Destroy(gameObject);
        Destroy(obj_txt);
        itemCounter.OnItemFound();// —ообщаем ItemCounter о том, что предмет был найден
        
    }

}
