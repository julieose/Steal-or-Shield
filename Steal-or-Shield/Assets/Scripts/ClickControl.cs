using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ClickControl1 : MonoBehaviour
{
    public static string obj_name;
    public GameObject obj_txt;
    //public Transform MyPartSys;
    //public ItemCounter itemCounter;// —сылка на объект ItemCounter
    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public static string obj_name;
    //public GameObject obj_txt;

    void OnMouseDown()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Instantiate(MyPartSys, obj_txt.transform.position, MyPartSys.rotation);

        ClickTrack.TotalClick = 0;
        //Link the object and the text
        obj_name = gameObject.name;
        //Debug.Log (obj_name);
        //Destroy the object and the text

        //itemCounter.OnItemFound();// —ообщаем ItemCounter о том, что предмет был найден
        Destroy(gameObject);
        Destroy(obj_txt);
        //itemCounter.foundItemsCount++;
        //if (itemCounter.foundItemsCount >= itemCounter.totalItemsToFind)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}

    }

}
