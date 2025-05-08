using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int vidaPlayer = 100;
    public float velocidadeCorrida = 10;
    public float velocidadeAndar = 5;
    public Camera cameraPlayer;

    private float velocidadePlayer;
    private Vector3 direcoes;
    // private Animator anim;

    void Start()
    {
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float Inputz = Input.GetAxis("Vertical");
        float InputRun = Input.GetAxis("correr");

        direcoes = new Vector3(InputX,0,Inputz);

        if(InputX != 0 || Inputz != 0)
        {
            var camRotation = cameraPlayer.transform.rotation;
            camRotation.x = 0;
            camRotation.z = 0;
            // anim.SetBool("walk",true);
            transform.Translate(0,0,velocidadePlayer*Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcoes)*camRotation, 5 * Time.deltaTime);
        
            if(InputRun != 0)
            {
                // anim.SetBool("camuflando",true);
                velocidadePlayer = velocidadeCorrida;
            }
            else
            {
                // anim.SetBool("camuflando",false);
                velocidadePlayer = velocidadeAndar;
            }
        }
        else if (InputX == 0 && Inputz == 0)
        {
            // anim.SetBool("walk",false);
            // anim.SetBool("camuflando",false);
        }

        if(vidaPlayer <= 0 )
        {
            SceneManager.LoadScene("Perdeu");
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("colidiu");
        if(collider.gameObject.tag == "maoInimiga")
        {
            Debug.Log(vidaPlayer);
            vidaPlayer -= 20;
        }
    }
}
