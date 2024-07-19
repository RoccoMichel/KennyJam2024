using UnityEngine;

public class Mistake : MonoBehaviour
{
    public int index = 0;
    public ParticleSystem FindPartical;

    private void Awake()
    {
        gameObject.tag = "Mistake";
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !Options._paused)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().FoundMistake();
            foreach (GameObject MistakeObj in GameObject.FindGameObjectsWithTag("Mistake"))
            {
                if (MistakeObj.GetComponent<Mistake>().index == index)
                {
                    MistakeObj.GetComponent<Mistake>().FindEffect();
                    Destroy(MistakeObj, 0f); //Destroy after particlesystem duration
                    break;
                }
            }
            FindEffect();
            //Play Sound

            Destroy(gameObject, 0f); //Destroy after particlesystem duration
        }
    }

    public void FindEffect()
    {
        //Play Effect
    }
}
