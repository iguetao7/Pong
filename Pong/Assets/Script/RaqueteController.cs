using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Criando o Vector3 para movimenta��o
    private Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 5f;
    public float meuLimite = 3.5f;

    //Identificando o player
    public bool player1;

    //Checando se deve ser controlado por IA
    public bool automatico = false;

    //Descobrindo a posi�ao da bola
    public Transform tranformBola;

    // Start is called before the first frame update
    void Start()
    {
        //Posi��o inical da raquete
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Passando meuY para o eixo Y da minhaPosicao
        minhaPosicao.y = meuY;

        //mudando a posi��o da raquete
        transform.position = minhaPosicao;

        //Velocidade final (velocidade * time.deltatime)
        float deltaVelocidade = velocidade * Time.deltaTime;

        //Se o automatico for False
        if (!automatico)
        {

            //Player 1 jogando
            if (player1)
            {
                //Movimento para cima player1
                if (Input.GetKey(KeyCode.W))
                {
                    //A��o de quando pressionar setinha para cima
                    //multiplicando pelo deltaTime ajusta os frames do jogo
                    meuY = meuY + deltaVelocidade;
                }

                //Movimento para baixo player1
                if (Input.GetKey(KeyCode.S))
                {

                    //A��o para quando pressionar setinha para baixo
                    //multiplicando pelo deltaTime ajusta os frames do jogo
                    meuY = meuY - deltaVelocidade;

                }
            }

            //Player 2 jogando
            else
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    automatico = true;
                }

                //Movimento para cima player 2
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //A��o de quando pressionar W
                    meuY = meuY + deltaVelocidade;
                }

                //Movimento para baixo player2
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //A��o para quando pressionar S
                    meuY = meuY - deltaVelocidade;
                }
            }
        }

        else
        {
            //Conferindo se player 2 esta jogando e desabilitando o automatico
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }

            //Seguindo a bola com o player automatico com delay
            meuY = Mathf.Lerp(meuY, tranformBola.position.y, 0.02f);
            
        }

        //Colis�o Superior dos players
        if (meuY > meuLimite)
        {
            meuY = meuLimite;
        }

        //Colis�o Inferior dos players
        if (meuY < -meuLimite)
        {
            meuY = -meuLimite;
        }
    }
}
