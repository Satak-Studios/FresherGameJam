using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource sfxObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }  
    }

    public void PlaySFXClip(AudioClip audioclip,Transform spawnTransform,float SFXVolume)
    {
        AudioSource audioSource = Instantiate(sfxObject,spawnTransform.position,Quaternion.identity);

        audioSource.clip = audioclip;
        audioSource.volume = SFXVolume;
        audioSource.Play();
        float cliplength = audioSource.clip.length;

        Destroy(audioSource.gameObject,cliplength);
        Debug.Log(cliplength);
    }

}
