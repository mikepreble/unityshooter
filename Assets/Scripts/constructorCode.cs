public class Unity
{
    public bool isInitialized;
    public Unity()
    {
        isInitialized = true;
    }
}

class UnityUser
{
    static void Main()
    {
        Unity u = new Unity();
        Console.WriteLine(t.isInitialized);
    }
}
