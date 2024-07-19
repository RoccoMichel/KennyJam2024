using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int mistakesLeft = 0;
    void Start()
    {
        foreach (GameObject Mistake in GameObject.FindGameObjectsWithTag("Mistake")) mistakesLeft++;
        Debug.Log($"Totall Mistakes in Scene: {mistakesLeft}");
        if (mistakesLeft % 2 != 0) Debug.LogWarning("UNEVEN AMOUNT OF MISTAKES IN SCENE!");
    }

    public void FoundMistake()
    {
        mistakesLeft -= 2;
    }
}
