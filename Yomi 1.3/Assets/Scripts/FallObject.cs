using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))] // Adiciona o componente de fisica ao objeto

public class FallObject : MonoBehaviour
{

    public float distanceToFall; // Distancia pro objeto começar a cair
    private bool canFall; // Verifica se o objeto pode cair
    private Rigidbody2D rb; // Componente de fisica
    private Transform playerTransform; // Transform do player(alvo)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Atribui componente de fisica
        rb.gravityScale = 0; // Deixa a gravidade do obj em zero, para que fique suspenso
        playerTransform = GameObject.FindWithTag("Player").transform; // Atribui a localizaçao do player no jogo
    }

    void Update()
    {
        // Verifica as distancias no eixo X entre esse obj e o player, caso essa distancia for menor que a distancia configurada, o objeto cai
        if (Vector3.Distance(transform.position,
        new Vector3(playerTransform.position.x, transform.position.y, transform.position.z)) < distanceToFall)
        {
            rb.gravityScale = 1;
            canFall = true;
        }

        if (canFall) // Desativa esse script quando o objeto ganha gravidade, para melhorar a performance
            this.enabled = false;
    }

}