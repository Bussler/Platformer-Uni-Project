

public class GameData
{


    private static GameData instance;
    private GameData()
    {
        if (instance != null)
            return;
        instance = this;
        Paused = false;
    }
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    private int lives = 5;
    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    public bool Paused
    {
        get;
        set;
    }
}
