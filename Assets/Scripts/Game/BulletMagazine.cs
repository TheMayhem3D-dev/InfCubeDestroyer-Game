using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMagazine : MonoBehaviour
{
    [SerializeField] private int maxBulletAmount = 5;
    private int currentBulletAmount;
    [SerializeField] private float reloadRate = 1f;
    private Timer reloadRateTimer;

    private void Awake()
    {
        SetComponents();
        SetProperties();
    }

    private void SetComponents()
    {
        reloadRateTimer = new Timer(reloadRate);
    }

    private void SetProperties()
    {
        currentBulletAmount = maxBulletAmount;
    }

    private void Update()
    {
        reloadRateTimer.UpdateTimer();
        TryReload();
    }

    private void TryReload()
    { 
        if(reloadRateTimer.IsTimerStoped())
        {
            AddBullet();
        }
    }

    public void AddBullet()
    {
        if (currentBulletAmount < maxBulletAmount)
            currentBulletAmount++;
    }

    public void RemoveBullet()
    {
        if (CanShoot())
            currentBulletAmount--;
    }

    public bool CanShoot()
    {
        return currentBulletAmount > 0;
    }
}
