using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

[System.Serializable]
public class HighScoreEntry
{
    public string name;
    public int score;
    public bool lastGame = false;

    public HighScoreEntry(string name, int score, bool lastGame = false)
    {
        this.name = name;
        this.score = score;
        this.lastGame = lastGame;
    }
}

public class Globals : Singleton<Globals>
{
    public GameObject playerPrefab;

    public List<HighScoreEntry> highScores;

    private int maxNumberOfHighScores = 10;

    private int lives = 3;

    private int score = 0;

    private GameObject player;

    private const string key_HighScores_Names = "highScores_Names";
    private const string key_HighScores_Values = "highScores_Values";

    private Vector2 designSize = new Vector2(1810, 825);

    public float ratio;

    private Vector3 ratioV3;

    private void Start()
    {
        this.ratio = Screen.width / this.designSize.x;

        this.ratioV3 = new Vector3(this.ratio, this.ratio, 1.0f);

        this.highScores = new List<HighScoreEntry>();

        string[] scores_Names = PlayerPrefsX.GetStringArray(key_HighScores_Names);
        int[] scores_Values = PlayerPrefsX.GetIntArray(key_HighScores_Values);

        for (int i = 0; i < scores_Names.Length; i++)
        {
            this.highScores.Add(new HighScoreEntry(scores_Names[i], scores_Values[i]));
        }
    }

    public void addToScore(int value)
    {
        this.score = this.score + value;
    }

    public bool GameRunning()
    {
        return this.player != null;
    }

    public void playerWasDestroyed()
    {
        this.lives--;

        if (this.lives <= 0)
        {
            this.player = null;

            this.BroadcastAll("EndGame", null);

            this.highScores.ForEach((value) => value.lastGame = false);

            this.highScores.Add(new HighScoreEntry("Charlie (" + System.DateTime.Now.ToString() + ")", this.score, true));

            this.highScores.Sort((p, q) => q.score.CompareTo(p.score));

            this.highScores = this.highScores.Take(this.maxNumberOfHighScores).ToList();
        }
        else
        {
            this.player = Instantiate(this.playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, this.ratioV3);

        GUILayout.BeginArea(new Rect(20, 20, Screen.width - 40, Screen.height - 40));

        GUILayout.BeginHorizontal();

        if (this.GameRunning())
        {
            GUILayout.BeginVertical(GUILayout.Width(150));

            if (GUILayout.Button("End game"))
            {
                Pause.Instance.UnPause();

                this.lives = 0;

                this.player.SendMessage("destroy");
            }

            if (this.GameRunning())
            {

                GUILayout.Label("Lives: " + this.lives.ToString());

                GUILayout.Space(10);

                GUILayout.Label("Score: " + this.score.ToString());


                Pause.Instance.GUI();


                GUILayout.EndVertical();


                if (!Pause.Instance.isPaused())
                {

                    GUILayout.BeginVertical(GUILayout.Width(150));

                    Asteroids.Instance.GUI();

                    GUILayout.EndVertical();


                    this.player.SendMessage("GUI");


                    GUILayout.BeginVertical(GUILayout.Width(150));

                    FlyingSaucers.Instance.GUI();

                    GUILayout.EndVertical();


                    GUILayout.BeginVertical(GUILayout.Width(150));

                    PowerUps.Instance.GUI();

                    GUILayout.EndVertical();
                }
            }
        }
        else
        {

            GUILayout.BeginVertical(GUILayout.Width(150));

            if (GUILayout.Button("Start game"))
            {
                this.lives = 3;

                this.score = 0;

                this.player = Instantiate(this.playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

                this.BroadcastAll("StartGame", null);
            }

            GUILayout.EndVertical();

            GUILayout.BeginVertical(GUILayout.Width(500));

            GUILayout.Label("High scores");

            GUILayout.Space(10);

            foreach (HighScoreEntry highscore in this.highScores)
            {
                if (highscore.lastGame)
                {
                    GUILayout.Label(highscore.name + ": " + highscore.score.ToString() + " <");
                }
                else
                {
                    GUILayout.Label(highscore.name + ": " + highscore.score.ToString());
                }
            }

            GUILayout.EndVertical();
        }

        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    public void BroadcastAll(string fun, System.Object msg)
    {
        GameObject[] gos = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject go in gos)
        {
            if (go && go.transform.parent == null)
            {
                go.gameObject.BroadcastMessage(fun, msg, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void OnApplicationQuit()
    {

    }

    private void OnDestroy()
    {
        string[] scores_Names = (from o in this.highScores select o.name).ToArray();
        int[] scores_Values = (from o in this.highScores select o.score).ToArray();

        PlayerPrefsX.SetStringArray(key_HighScores_Names, scores_Names);
        PlayerPrefsX.SetIntArray(key_HighScores_Values, scores_Values);
    }
}


