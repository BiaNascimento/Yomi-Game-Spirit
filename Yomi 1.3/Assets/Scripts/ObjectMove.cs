using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Adiciona um Rigidbody ao objeto

public class ObjectMove : MonoBehaviour
{

    public float height, speed;
    // Height é altura(em segundos) da onde ate o objeto pode alcançar, speed é a velocidade do movimento
    private bool canUp; // Verifica se o objeto pode subir
    private Rigidbody2D rb; // Componente de física do objeto

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Atribui componentes da física desse objeto
        rb.constraints = RigidbodyConstraints2D.FreezePositionX; // Congela a movimentação no eixo X
        rb.gravityScale = 0; // Faz com que o objeto não tenha gravidade

        if (height < 0) // Previne que a altura seja um valor negativo
            height = 0.1f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Caso o objeto colida com algo que tenha a tag "Ground"(chão) quer dizer que atingiu seu ponto mínimo, e então volta a subir
        if (other.gameObject.tag == "Ground")
            canUp = !canUp;

        // Se o objeto está subindo, inicia uma corritina para esperar um tempo(altura) pra ele voltar a descer
        if (canUp)
            StartCoroutine("TimeToWait");
    }

    void FixedUpdate()
    {
        var direction = 1; // Direção do movimento do objeto
        direction = canUp ? direction : -direction; // Se pode subir, ele fica positivo(sobe) se não, fica negativo(desce)
        rb.velocity = new Vector2(0, speed * direction); // Faz a movimentação do objeto de acordo com a direção e a velocidade
    }

    IEnumerator TimeToWait()
    {
        // Espera o tempo determinado pela altura para alcançar seu ponto máximo e voltar a descer
        yield return new WaitForSeconds(height);
        canUp = false;
    }
}