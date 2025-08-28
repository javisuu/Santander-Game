using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D cuerpo;
    AudioSource sfx;
    public AudioClip[] efectos;
    float mov;
    bool verDerecha = true;
    public bool jump = true;
    public Transform pies;
    float fuerzaSalto = 300f;
    float feetSize = 0.2f;
    public LayerMask QueEsSuelo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        cuerpo = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        jump=!Physics2D.OverlapCircle(pies.position, feetSize, QueEsSuelo);
        if (Input.GetKey(KeyCode.K)) //K es el boton de ataque, podemos cambiarlo por el boton que queramos
        {//Indicamos el dispositivo real (xbox, playstation...)
            anim.Play("playerPunch");
            sfx.clip = efectos[1];
            sfx.Play();

        }
        if (Input.GetKeyDown(KeyCode.Space) && !jump) //uparrow tambien funciona
        {
            cuerpo.AddForce(new Vector2(0, fuerzaSalto));
            sfx.clip = efectos[0];
            sfx.Play();
        }
        mov = Input.GetAxis("Horizontal");
        anim.SetFloat("MOV", Mathf.Abs(mov));
        anim.SetBool("Jump", jump);
        anim.SetFloat("ALTURA", cuerpo.linearVelocity.y);
        cuerpo.linearVelocity = new Vector2(mov * 5, cuerpo.linearVelocity.y);
        if (verDerecha && mov < 0)
        {
            Flip();
        }
        else if (!verDerecha && mov > 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        verDerecha = !verDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
