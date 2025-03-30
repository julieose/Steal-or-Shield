using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private GameObject[] puzzle;
    public static bool isCorrect;

    private void Start()
    {
        puzzle = GameObject.FindGameObjectsWithTag("Puzzle");
        isCorrect = false;
    }

    private void Update()
    {
        bool allTrue = true;
        foreach (var item in puzzle)
        {
            if(item.transform.rotation.z < -0.01 || item.transform.rotation.z > 0.01)
            {
                allTrue = false; break;
            }
        }
        if (allTrue)
        {
            isCorrect = true;
            Debug.Log("YOU WIN");
        }
        PuzzleRotate.isMouse = false;
    }
}
