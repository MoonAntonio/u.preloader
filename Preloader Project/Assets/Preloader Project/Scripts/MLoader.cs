//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MLoader.cs (22/02/2017)						    							\\
// Autor: Antonio Mateo (Moon Pincho) 									        \\
// Descripcion:		Loader de escena con un fade en UGUI y NGUI					\\
// Fecha Mod:		22/02/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonPincho
{
#if NGUI
    /// <summary>
    /// <para>Loader de escena con un fade en UGUI y NGUI</para>
    /// </summary>
    public class MLoader : MonoBehaviour 
	{
        #region Variables Privadas
        /// <summary>
        /// <para>UISprite para hace el fade.</para>
        /// </summary>
        private UISprite fade;                                              // UISprite para hace el fade
        /// <summary>
        /// <para>Tiempo que tiene que transcurrir.</para>
        /// </summary>
        private float tiempoTranscurrido = 0.0f;                            // Tiempo que tiene que transcurrir
        /// <summary>
        /// <para>Tiempo minimo de la escena.</para>
        /// </summary>
        private float tiempoLogo = 5.0f;                                    // Tiempo minimo de la escena
        #endregion

        #region Init
        /// <summary>
        /// <para>Init de MLoader.</para>
        /// </summary>
        private void Start()// Init de MLoader
        {
            // Buscamos el Fade
            fade = GameObject.Find("Fade").GetComponent<UISprite>();

            // Empezamos la escena en blanco
            fade.alpha = 1;

            // Controlamos el tiempo para que no pase nada al cargar la escena varias veces
            if (Time.time < tiempoLogo)
            {
                tiempoTranscurrido = tiempoLogo;
            }
            else
            {
                tiempoTranscurrido = Time.time;
            }
        }
        #endregion

        #region Actualizador
        /// <summary>
        /// <para>Actualizador de MLoader.</para>
        /// </summary>
        private void Update()// Actualizador de MLoader
        {
            // Fade-in
            if (Time.time < tiempoLogo)
            {
                fade.alpha = 1 - Time.time;
            }

            // Fade-out
            if (Time.time > tiempoLogo && tiempoTranscurrido != 0)
            {
                fade.alpha = Time.time - tiempoLogo;
                if (fade.alpha >= 1)
                {
                    // Accion despues del Fade
                    Debug.Log("Cambiando de escena ...");
                }
            }
        }
        #endregion

    }
#else
    /// <summary>
    /// <para>Loader de escena con un fade en UGUI y NGUI</para>
    /// </summary>
    public class MLoader : MonoBehaviour 
	{
    #region Variables Privadas
        /// <summary>
        /// <para>Canvas para hacer el fade.</para>
        /// </summary>
        private CanvasGroup fade;                                           // Canvas para hacer el fade
        /// <summary>
        /// <para>Tiempo que tiene que transcurrir.</para>
        /// </summary>
        private float tiempoTranscurrido = 0.0f;                            // Tiempo que tiene que transcurrir
        /// <summary>
        /// <para>Tiempo minimo de la escena.</para>
        /// </summary>
        private float tiempoLogo = 5.0f;                                    // Tiempo minimo de la escena
    #endregion

    #region Init
        /// <summary>
        /// <para>Init de MLoader.</para>
        /// </summary>
        private void Start()// Init de MLoader
        {
            // Buscamos el CanvasGroup
            fade = FindObjectOfType<CanvasGroup>();

            // Empezamos la escena en blanco
            fade.alpha = 1;

            // Controlamos el tiempo para que no pase nada al cargar la escena varias veces
            if (Time.time < tiempoLogo)
            {
                tiempoTranscurrido = tiempoLogo;
            }
            else
            {
                tiempoTranscurrido = Time.time;
            }
        }
    #endregion

    #region Actualizador
        /// <summary>
        /// <para>Actualizador de MLoader.</para>
        /// </summary>
        private void Update()// Actualizador de MLoader
        {
            // Fade-in
            if (Time.time < tiempoLogo)
            {
                fade.alpha = 1 - Time.time;
            }

            // Fade-out
            if (Time.time > tiempoLogo && tiempoTranscurrido != 0)
            {
                fade.alpha = Time.time - tiempoLogo;
                if (fade.alpha >= 1)
                {
                    // Accion despues del Fade
                    Debug.Log("Cambiando de escena ...");
                }
            }
        }
    #endregion
    }
#endif
}
