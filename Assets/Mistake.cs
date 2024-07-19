using UnityEngine;

public class Mistake : MonoBehaviour
{
    public int index = 0;
    public ParticleSystem FindPartical;
    public bool _find;

    private void Awake()
    {
        gameObject.tag = "Mistake";
        _find = false;
    }



    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !Options._paused)
        {
            _find = true;
        }
        
        if (Input.GetMouseButtonUp(0) && !Options._paused && _find)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().FoundMistake();
            foreach (GameObject MistakeObj in GameObject.FindGameObjectsWithTag("Mistake"))
            {
                if (MistakeObj.GetComponent<Mistake>().index == index && MistakeObj != gameObject)
                {
                    MistakeObj.GetComponent<Mistake>().FindEffect();
                    Destroy(MistakeObj, 0f); //Destroy after particlesystem duration
                    break;
                }
            }
            FindEffect();
            AudioSource.PlayClipAtPoint(GameAssets.i.findSFX, Camera.main.transform.position);

            Destroy(gameObject, 0f); //Destroy after particlesystem duration
        }
    }

    public void FindEffect()
    {
        Instantiate(GameAssets.i.findParticale, gameObject.transform.position, Quaternion.identity);
    }
}
