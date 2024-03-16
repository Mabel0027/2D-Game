using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Importa el espacio de nombres para TextMeshPro

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    public Text nivelText;
 
    private int nivel = 1; // Número de nivel

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam = Camera.main.GetComponent<CameraController>();
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                nivel++; // Incrementa el número de nivel
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);
                nivel--; // Decrementa el número de nivel
            }

            // Actualiza el texto del objeto TextLegacy con el número de nivel
            nivelText.text = "Nivel " + nivel;
        }
    }
}
