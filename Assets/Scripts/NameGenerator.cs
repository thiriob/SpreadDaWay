using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    private string[] NameStart =
        {"dark", "lord", "xXx", "xX", "kevin", "master", "x", "x0r", "strong", "negi", "l0rd", "n00b", "m4st3r", "pro", "pvp"};
    private string[] NameMiddle = { "Sasuke", "Naruto", "Hanzo", "Pikachu", "Funeral", "kevin", "master", "tiger", "bomb", "h4ck3r", "sx", "69", "42", "123", "420", "pvp", "Tintin", "craft" };
    private string[] NameEnd = { "1999", "12", "2001", "2010", "1402", "420", "69", "720", "2018", "24", "2", "Xx", "Xxx" };

    public string CreateUsername()
    {
        string Username = "";
        int rStart = (int)Random.Range(0, NameStart.Length);
        int rMiddle = (int)Random.Range(0, NameMiddle.Length);
        Username = NameStart[rStart] + NameMiddle[rMiddle];
        if (Random.Range(0, 10) > 5f)
        {
            int rEnd = (int)Random.Range(0, NameEnd.Length);
            Username += NameEnd[rEnd];
        }
        return Username;
    }
}
