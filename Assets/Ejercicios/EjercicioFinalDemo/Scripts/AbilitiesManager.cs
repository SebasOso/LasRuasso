using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    [SerializeField] private Material gaussMat;
    [SerializeField] private GameObject tornadoPrefab;
    [SerializeField] private GameObject waterLaserPrefab;
    [SerializeField] private GameObject fireBallPrefab;
    private InputReader inputReader;
    [SerializeField] private Transform tornadoSpawnPosition;
    void Start()
    {
        inputReader = GetComponent<InputReader>();
        inputReader.Tornado += TornadoAnim;
        inputReader.WaterLaser += WaterLaserAnim;
        inputReader.FireBall += FireBallAnim;
    }
    public void TornadoAnim()
    {
        GetComponent<PlayerStateMachine>().IsTornado = true;
    }
    public void WaterLaserAnim()
    {
        GetComponent<PlayerStateMachine>().IsWaterLaser = true;
    }
    public void FireBallAnim()
    {
        GetComponent<PlayerStateMachine>().IsFireBall = true;
    }
    public void CastTornado()
    {
        print("TORNADO");
        GameObject tornado = Instantiate(tornadoPrefab, tornadoSpawnPosition.position, Quaternion.Euler(new Vector3(0,0,0)));
        StartCoroutine(IncreaseGauss());
        StartCoroutine(Tornado(tornado));
    }
    public void CastFireBall()
    {
        print("FIRE BALL");
        fireBallPrefab.SetActive(true);
        fireBallPrefab.GetComponent<ParticleSystem>().Clear();
        fireBallPrefab.GetComponent<ParticleSystem>().Play();
        StartCoroutine(FireBall(fireBallPrefab));
    }
    public void CastWaterLaser()
    {
        print("WATER LASER");
        waterLaserPrefab.SetActive(true);
        StartCoroutine(WaterLaser(waterLaserPrefab));
    }
    private IEnumerator Tornado(GameObject tornado)
    {
        yield return new WaitForSeconds(9f);
        StartCoroutine(DecreaseGauss());
        inputReader.IsCasting = false;
        Destroy(tornado);
    }
    private IEnumerator WaterLaser(GameObject waterLaser)
    {
        yield return new WaitForSeconds(3f);
        inputReader.IsCasting = false;
        waterLaser.SetActive(false);
    }
    private IEnumerator FireBall(GameObject fireBall)
    {
        yield return new WaitForSeconds(5f);
        inputReader.IsCasting = false;
        fireBall.SetActive(false);
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
