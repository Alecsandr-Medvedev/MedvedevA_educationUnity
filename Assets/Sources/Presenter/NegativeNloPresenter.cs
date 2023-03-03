using UnityEngine;

public class NegativeNloPresenter : Presenter
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyCompose();
        }
    }
}
