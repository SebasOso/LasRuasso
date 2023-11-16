using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    [SerializeField] private Material gaussMat;
    [SerializeField] private GameObject tornadoPrefab;
    private InputReader inputReader;
    [SerializeField] private Transform tornadoSpawnPosition;

    void Start()
    {
        inputReader = GetComponent<InputReader>();
        inputReader.Tornado += TornadoAnim;
    }
    public void TornadoAnim()
    {
        GetComponent<PlayerStateMachine>().IsTornado = true;
    }
    public void CastTornado()
    {
        print("TORNADO");
        GameObject tornado = Instantiate(tornadoPrefab, tornadoSpawnPosition.position, Quaternion.Euler(new Vector3(0,0,0)));
        StartCoroutine(IncreaseGauss());
        StartCoroutine(Tornado(tornado));
    }
    private IEnumerator Tornado(GameObject tornado)
    {
        yield return new WaitForSeconds(9f);
        StartCoroutine(DecreaseGauss());
        inputReader.IsCasting = false;
        Destroy(tornado);
    }
    private IEnumerator IncreaseGauss()
    {
        float initialValue = 0f;
        float targetValue = 9f;
        int steps = 1000;
        float stepValue = (targetValue - initialValue) / steps;
        for (int i = 0; i <= steps; i++)
        {
            gaussMat.SetFloat("_PixelOffSet", initialValue + i * stepValue);
            yield return null;
        }
    }
    private IEnumerator DecreaseGauss()
    {
        float initialValue = 9f;
        float targetValue = 0f;
        int steps = 1000;
        float stepValue = (targetValue - initialValue) / steps;
        for (int i = 0; i <= steps; i++)
        {
            gaussMat.SetFloat("_PixelOffSet", initialValue + i * stepValue);
            yield return null;
        }
        gaussMat.SetFloat("_PixelOffSet", 0f);
    }
}
