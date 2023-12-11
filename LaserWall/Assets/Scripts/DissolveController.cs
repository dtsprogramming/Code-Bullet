using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolveController : MonoBehaviour
{
    [Header("Dissolve")]
    [SerializeField] private VisualEffect VFXGraph;
    [SerializeField] private float refreshRate = 0.175f;
    [SerializeField] private float dissolveRate = 0.2f;

    private SkinnedMeshRenderer[] skinnedMeshes;
    private List<Material> skinnedMaterials = new List<Material>();

    [Header("Animate")]
    [SerializeField] private Animator anim;

    [Header("Audio")]
    [SerializeField] private AudioClip zombieScream;
    [SerializeField] private AudioSource zombieAudio;

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var skinnedMesh in skinnedMeshes)
        {
            skinnedMaterials.Add(skinnedMesh.material);
        }
    }

    public void ZombieDeathAnim()
    {
        KillZombie();
    }

    private void KillZombie()
    {
        anim.SetBool("IsDying", true);
        
        if (zombieAudio != null)
        {
            zombieAudio.PlayOneShot(zombieScream);
        }
    }

    public void DissolveZombie()
    {
        StartCoroutine(DissolveCo());
    }

    IEnumerator DissolveCo()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }

        if (skinnedMaterials != null)
        {
            float counter = 0;

            while (skinnedMaterials[0].GetFloat("_Dissolve_Amount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < skinnedMaterials.Count; i++)
                {
                    skinnedMaterials[i].SetFloat("_Dissolve_Amount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }

            Destroy(gameObject);
        }
    }
}
