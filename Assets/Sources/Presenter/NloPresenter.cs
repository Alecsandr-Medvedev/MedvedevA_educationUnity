using UnityEngine;

public class NloPresenter : Presenter
{
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyCompose();
        }
    }
}
