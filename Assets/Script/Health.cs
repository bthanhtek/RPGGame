using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    public bool isDeath = false;


    public void InitializeHealth(int HeathValue)
    {
        currentHealth = HeathValue;
        maxHealth = HeathValue;
        isDeath = false;
    }


    public void GetHit(int amount, GameObject sender)

    {
        if (isDeath)
        {
       
            return;
        }


        if (sender.name == gameObject.name)
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference.Invoke(sender);
        }
        else
        {
            
            OnDeathWithReference.Invoke(sender);
            isDeath = true;
            StartCoroutine(delayTime());
           
        }

    }

    IEnumerator delayTime()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1);
        print(Time.time);
        Destroy(gameObject);
    }
}
