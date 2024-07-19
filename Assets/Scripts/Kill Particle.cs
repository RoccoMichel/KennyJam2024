using UnityEngine;

public class KillParticle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().main.duration);
    }
}
