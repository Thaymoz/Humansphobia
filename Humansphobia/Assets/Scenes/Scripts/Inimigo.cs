using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Inimigo : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private GameObject player;
    private Animator animInimigo;
    private GameObject maoInimigo;
    public float velocidadeDoInimigo;
    



    // Start is called before the first frame update
    void Start()
    {
        navMesh= GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        maoInimigo = GameObject.FindWithTag("maoInimiga");
        animInimigo = GetComponent<Animator>();
        navMesh.speed = velocidadeDoInimigo;
        maoInimigo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = player.transform.position;
        // animInimigo.SetBool("walk",true);
        if (Vector3.Distance(transform.position, player.transform.position)< 1.5f)
        {
            navMesh.speed = 0;
            maoInimigo.SetActive(true);
            animInimigo.SetBool("atack",true);
            StartCoroutine("ataque");
        }
    }
    IEnumerator ataque()
    {
        yield return new WaitForSeconds(0.2f);
        animInimigo.SetBool("atack",false);
        yield return new WaitForSeconds(2.8f);
        maoInimigo.SetActive(false);
        navMesh.speed = velocidadeDoInimigo;
    }
}
