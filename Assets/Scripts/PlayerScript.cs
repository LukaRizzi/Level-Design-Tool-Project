using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private bool started = false; [HideInInspector] public bool dead = false; //Variables para que el jugador no se pueda mover en algunos momentos

    [Header("Movimiento")]
    public float velocidadMovimiento = 5;
    public float velocidadMax = 10;
    public float fuerzaDeSalto = 20;
    public float velocidadDeCaidaMax = 10;
    [SerializeField] private PlayerAnimation animacion;

    [Header("Autorunner")]
    public Vector2 fuerzaConstante = Vector2.zero;

    [Header("Movimiento avanzado")]
    public bool saltarSoloEnPiso = false;
    [SerializeField] private float tiempoCoyote = .2f;
    private float coyoteTimer = 0;
    [SerializeField] private float bufferDeSalto = .3f;
    private float bufferTimer = 0;
    private float jumpCD = 0;
    public bool multiplicarGravedadEnCaida = false;
    public float multiplicadorDeGravedadEnCaida = 2f;
    public bool saltoVariable = false;
    public float multiplicadorDeGravedadEnSalto = .5f;
    private bool jumped = false; //Voy a programar esto medio así nomás xq estoy con paja hoy pero quiero que ande
    private float normalGrav;
    public bool saltoDePared = false;
    public float fuerzaHorizontalDeSaltoDePared;
    public float fuerzaVerticalDeSaltoDePared;

    [HideInInspector] public Rigidbody2D rb;
    private AudioSource aSource; //Para reproducir audio al saltar

    private bool grounded => rb.IsTouching(contactoPiso);

    private bool wallRight => CheckWallRight();
    private bool wallLeft => CheckWallLeft();

    [Header("Ignorar esto")]
    public ContactFilter2D contactoPiso;
    public LayerMask whatIsGround;

    private Transform spriteChild;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
        normalGrav = rb.gravityScale;
        spriteChild = gameObject.GetComponentInChildren<SpriteRenderer>().transform;
    }

    void Update()
    {
        if (dead) //Si el jugador está muerto, no correr el movimiento
        {return;}
        if (!started) //Si el jugador no empezó el nivel, no aplicar gravedad ni nada
        {
            if (Input.GetKeyDown(KeyCode.Space)) //Al apretar espacio empezar el juego
            {
                started = true;
                rb.isKinematic = false;
            }
            else
            {
                return;
            }
        }

        float _grav = normalGrav;
        if (multiplicarGravedadEnCaida && rb.velocity.y <= 0)
        {
            _grav *= multiplicadorDeGravedadEnCaida;
        }

        rb.gravityScale = _grav;

        //Jump calculating
        bool pressedJump = Input.GetKeyDown(KeyCode.Space);
        bufferTimer = pressedJump ? bufferDeSalto : bufferTimer -= Time.deltaTime;
        coyoteTimer = grounded ? tiempoCoyote : coyoteTimer -= Time.deltaTime;
        jumpCD -= Time.deltaTime;

        if ((((grounded && bufferTimer > 0) || (coyoteTimer > 0 && pressedJump)) || (!saltarSoloEnPiso && pressedJump)) && jumpCD < 0) //Si apreto espacio
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaDeSalto); //Cambiar toda la velocidad vertical a la fuerza de salto
            aSource.Play(); //Reproducir el audio de saltar
            bufferTimer = 0;
            coyoteTimer = 0;
            jumpCD = tiempoCoyote;
            spriteChild.localScale = grounded? new Vector3(animacion.saltoEnPiso.x, animacion.saltoEnPiso.y, 1) : new Vector3(animacion.saltoEnAire.x, animacion.saltoEnAire.y, 1); //Escalar personaje

            jumped = true;
        }
        else
        {
            if (wallRight != wallLeft && pressedJump)
            {
                float xDir = wallRight ? -1 : 1;
                rb.velocity = new Vector2(fuerzaHorizontalDeSaltoDePared * xDir, fuerzaVerticalDeSaltoDePared); //Cambiar toda la velocidad vertical a la fuerza de salto
                aSource.Play(); //Reproducir el audio de saltar
                bufferTimer = 0;
                coyoteTimer = 0;
                jumpCD = tiempoCoyote;

                spriteChild.localScale = new Vector3(animacion.saltoEnPared.x, animacion.saltoEnPared.y, 1); //Escalar personaje
            }
        }

        if (jumped)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumped = false;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * multiplicadorDeGravedadEnSalto);
            }
            else if (rb.velocity.y < 0)
            {
                jumped = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal == Vector2.up)
        {
            spriteChild.localScale = new Vector3(animacion.impactoCaida.x, animacion.impactoCaida.y, 1); //Escalar personaje
        }
    }

    private bool CheckWallRight()
    {
        return Physics2D.Raycast(transform.position,transform.right, 2f, whatIsGround) && saltoDePared;
    }

    private bool CheckWallLeft()
    {
        return Physics2D.Raycast(transform.position, -transform.right, 2f, whatIsGround) && saltoDePared;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, .08f), rb.velocity.y);
        rb.AddForce(fuerzaConstante + new Vector2(Input.GetAxisRaw("Horizontal") * velocidadMovimiento, 0)); //Moverme horizontalmente

        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -velocidadMax, velocidadMax),
            Mathf.Max(rb.velocity.y, -velocidadDeCaidaMax)); //Limitar velocidad

        spriteChild.localScale = Vector3.Lerp(spriteChild.localScale, Vector3.one, animacion.velocidadDeAnimacion);
    }
}