using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TtitleEffects : MonoBehaviour
{
    public GameObject title1;
    public ParticleSystem titleParticles;

    public TMP_Text titleText;
    Mesh txtMesh;
    Vector3[] verts;
    public float sinSpeed;
    public float cosSpeed;
    public Animator transition;
    private void Start()
    {
       
    }

    void Update()
    {
        titleText.ForceMeshUpdate();
        txtMesh = titleText.mesh;
        verts = txtMesh.vertices;

/*        for (int i = 0; i < verts.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);
            verts[i] = verts[i] + offset;
        }
*/
        for (int i = 0; i < titleText.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = titleText.textInfo.characterInfo[i];
            int index = c.vertexIndex;

            Vector3 offset = Wobble(Time.time+i);
            verts[index] += offset;
            verts[index +1] += offset;
            verts[index +2] += offset;
            verts[index +3] += offset;
        }

        txtMesh.vertices = verts;
        titleText.canvasRenderer.SetMesh(txtMesh);
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * sinSpeed), Mathf.Cos(time * cosSpeed));
    }

    public void ClickedPlay()
    {
        StartCoroutine(waitFor());
    }
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(0.5f);
        play();
        yield return new WaitForSeconds(1f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        NextScene();
    }

    void play()
    {
        title1.gameObject.SetActive(false);
        titleParticles.Emit(9999);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
