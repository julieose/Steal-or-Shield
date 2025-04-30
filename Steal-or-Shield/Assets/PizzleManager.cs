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
        CheckPuzzle();
    }

    private void Update()
    {
        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        bool allTrue = true;
        foreach (var item in puzzle)
        {
            float zRot = item.transform.rotation.eulerAngles.z;
            // Нормализуем угол в диапазон 0-360
            if (Mathf.Abs(Mathf.DeltaAngle(zRot, 0)) > 1f)
            {
                allTrue = false;
                break;
            }
        }
        if (allTrue && !isCorrect)
        {
            isCorrect = true;
            Debug.Log("YOU WIN");
        }
    }

}
