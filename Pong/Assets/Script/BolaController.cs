using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    //rigidbody para velocidade 
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;
    //Velocidade inicial
    public float velocidade = 5f;

    //Limite horizontal para saber se saiu da tela
    public float limiteHorizontal = 12f;

    //som boing
    public AudioClip boing;
    //ajuste do audio
    public Transform transformCamera;

    //Delay para iniciar o jogo de 2 seg
    public float delay = 2f;
    public bool jogoIniciado = false;

    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        //Iniciando o delay regressivo 
        delay = delay - Time.deltaTime;
        //Verificando de chegou foi os 2 segundos
        if (delay <= 0 && jogoIniciado == false)
        {
            Debug.Log("Chegou a zero");
            //alterando a variavel de controle
            jogoIniciado = true;

            //Iniciando o jogo
            //direção aleatoria para bola
            int direcao = Random.Range(0, 4);
            Debug.Log(direcao);
            //iniciando para superior direita
            if (direcao == 0)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;
            }
            //iniciando para superior esquerda
            else if (direcao == 1)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = velocidade;
            }
            //iniciando para inferior esquerda
            else if (direcao == 2)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = -velocidade;
            }
            //iniciando para inferior direita
            else
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = -velocidade;
            }

            //Velocidade inicial 
            meuRB.velocity = minhaVelocidade;
        }

        //Checando se a bola saiu da tela
        if (transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            //Recarregando a cena e ficando em looping
            SceneManager.LoadScene(0);
        }
    }

    //Evento de colisão para ter som
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Tocando um audio em uma posição
        AudioSource.PlayClipAtPoint(boing, transformCamera.position);
    }
}
