
using UnityEngine;
using UnityEngine.UI;// para modificacion de los datos
public class Ball : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;

	[HideInInspector] public Vector3 pos { get { return transform.position; } }
   
    public int score=0; // contador de score
	public Text txtScore; //texto
	
	public GameObject [] corazones; // array de vidas 3 en este caso
	private int vida; //
	void Start()
	{
		vida=corazones.Length;
	}
	void Update()
	{
		txtScore.text="Score: "+ score;
		//comprobacion de vidas
		if (vida<1)
		{
			Destroy(corazones[0].gameObject);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);// escena de game over
		}
		else if (vida <2)
		{
			Destroy(corazones[1].gameObject);
		}
		else if (vida <3)
		{
			Destroy(corazones[2].gameObject);
		}
	}
	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
	}

	public void Push (Vector2 force)
	{
		rb.AddForce (force, ForceMode2D.Impulse);
	}

	public void ActivateRb ()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb ()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Castle")
		{
			score++;
			Destroy(collision.gameObject);//destructor
			vida--; //vidas o intentos
		}
	}
}
