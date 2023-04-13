using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i { get; private set; }

    public GameObject[] enemyArray;

    public GameObject pfTriangle;
    public GameObject pfSquare;
    public GameObject pfCircle;

    public SoundAudioClip[] soundAudioClipArray;

    private void Awake() 
    {
        i = this;
    }

    private void Start() 
    {
        SoundManager.Setup(soundAudioClipArray);
    }

    public GameObject GetRandomEnemy() 
    {
        return enemyArray[Random.Range(0, enemyArray.Length)];
    }
}
