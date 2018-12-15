using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent (typeof (AudioSource))]
public class AudioPitchLevel : MonoBehaviour {


    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    [Header("LunaBody")]
    public GameObject GlowBody;
    public float bo_multiplier = 1;
    public float bo_minSize, bo_maxSize;

    [Header("LunaHorn")]
    public GameObject GlowHorn;
    public float ho_multiplier = 1;
    public float ho_minSize, ho_maxSize;



    private float currentUpdateTime = 0f;

    private float clipLoudness_body, clipLoudness_horn;

    private float clipLoudness;
    private float[] clipSampleData;

    // Use this for initialization
    void Awake()
    {

        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];

    }

    // Update is called once per frame
    void Update()
    {

        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            clipLoudness_body = clipLoudness*bo_multiplier;
            clipLoudness_body = Mapf.Map(clipLoudness_body,0,2,bo_minSize, bo_maxSize);
            GlowBody.transform.localScale = new Vector3( clipLoudness_body,clipLoudness_body,clipLoudness_body);

            clipLoudness_horn = clipLoudness*ho_multiplier;
            clipLoudness_horn = Mapf.Map(clipLoudness_horn,0,2,ho_minSize, ho_maxSize);
            GlowHorn.transform.localScale = new Vector3( clipLoudness_horn,clipLoudness_horn,clipLoudness_horn);



            Debug.Log(clipLoudness);
        }

    }

}
