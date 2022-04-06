using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    /* The CameraShake logic has been done with the help of: https://roystan.net/articles/camera-shake.html */
    public static CameraShake Instance;

    [SerializeField]
    private float _frequency = 25;

    [SerializeField]
    private Vector3 maximumTranslationShake = Vector3.one * 0.5f;

    [SerializeField]
    private Vector3 maximumAngularShake = Vector3.one * 2;

    [SerializeField]
    private float _recoverySpeed = 1.5f;

    [SerializeField]
    private float _traumaExponent = 2;

    private float _seed;
    private float _trauma = 0;

    private void Awake()
    {
        Instance = this;
        _seed = Random.value;
    }

    private void Update()
    {
        float shake = Mathf.Pow(_trauma, _traumaExponent);

        transform.localPosition = new Vector3(
            maximumTranslationShake.x * Mathf.PerlinNoise(_seed, Time.time * _frequency) * 2 - 1,
            maximumTranslationShake.y * Mathf.PerlinNoise(_seed + 1, Time.time * _frequency) * 2 - 1,
            maximumTranslationShake.z * Mathf.PerlinNoise(_seed + 2, Time.time * _frequency) * 2 - 1
        ) * shake;


        transform.localRotation = Quaternion.Euler(new Vector3(
            maximumAngularShake.x * (Mathf.PerlinNoise(_seed + 3, Time.time * _frequency) * 2 - 1),
            maximumAngularShake.y * (Mathf.PerlinNoise(_seed + 4, Time.time * _frequency) * 2 - 1),
            maximumAngularShake.z * (Mathf.PerlinNoise(_seed + 5, Time.time * _frequency) * 2 - 1)
        ) * shake);

        _trauma = Mathf.Clamp01(_trauma - _recoverySpeed * Time.deltaTime);
    }

    public void InduceStress(float stress)
    {
        _trauma = Mathf.Clamp01(_trauma + stress);
    }

}
