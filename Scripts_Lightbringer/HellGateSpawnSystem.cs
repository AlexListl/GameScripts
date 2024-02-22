using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellGateSpawnSystem : MonoBehaviour
{
    public GameObject casterDemon;
    public GameObject normalDemon;
    public GameObject empoweredDemon;

    public GameObject demonBoss;
    public LayerMask spawnedEnemys;
    public LayerMask player;

    public PlayerDetection detectionRange;
    bool methodBool=false;

    void Update()
    {
        if(detectionRange.getIsInCone())
        {
            initiateWaves();
        }
        sendSpawnedEnemiesAtPlayer();
    }

    void sendSpawnedEnemiesAtPlayer()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(GameObject.FindGameObjectWithTag("Gate").transform.position, 10, spawnedEnemys);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().portalAttack();
        }
    }

    void initiateWaves()
    {

        if(!methodBool)
        {
            StartCoroutine(initiatePortalRoutine());
            methodBool = true;
        }else
        {
            return;
        }

    }

    IEnumerator initiatePortalRoutine()
    {
            FindObjectOfType<TooltipTrigger>().showToolTipWithoutTrigger("First Wave in 15 Seconds!");
            yield return new WaitForSeconds(15);
            firstWave();
            FindObjectOfType<TooltipTrigger>().showToolTipWithoutTrigger("Second Wave in 30 Seconds!");
            yield return new WaitForSeconds(30);
            secondWave();
            FindObjectOfType<TooltipTrigger>().showToolTipWithoutTrigger("Third Wave in 45 Seconds!");
            yield return new WaitForSeconds(45);
            thirdWave();
            yield return new WaitForSeconds(45);
            FindObjectOfType<AudioManager>().Play("firstOmen");
            yield return new WaitForSeconds(5);
            FindObjectOfType<AudioManager>().Play("secondOmen");
            yield return new WaitForSeconds(7);
            FindObjectOfType<AudioManager>().Play("thirdOmen");
            yield return new WaitForSeconds(3);
            bossWave();        
    }

    void firstWave()
    {
        Instantiate(normalDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
        Instantiate(normalDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
        
    }

    void secondWave()
    {
        Instantiate(normalDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
        Instantiate(normalDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
        Instantiate(casterDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
    }

    void thirdWave()
    {
        Instantiate(empoweredDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
        Instantiate(empoweredDemon, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
    }

    void bossWave()
    {
        Instantiate(demonBoss, GameObject.FindGameObjectWithTag("Gate").transform.position+new Vector3(0,0,15), Quaternion.identity);
    }
}
