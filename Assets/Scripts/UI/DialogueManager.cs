using System.IO;
using System.Collections.Generic;
public class DialogueManager
{
    public List<Dialogue> DialogueList { get; }
    public DialogueManager()
    {
        //We should iterate every file inside the Dialogue directory and then concatenate it to DialogueList.
        DialogueList = ParseDialoguefile(@"C:\Users\giann\Progetti\Quackgame\Assets\Dialogue\dialogotest.csv");
    }

    private List<Dialogue> ParseDialoguefile(string path) 
    {
        List<Dialogue> result = new List<Dialogue>();
        StreamReader reader = new StreamReader(path);

        //We ignore the header
        reader.ReadLine();
        
        while(reader.Peek() >= 0 )
        {
            string[] line = reader.ReadLine().Split(';');
            result.Add(new Dialogue(ID: line[0], duration: int.Parse(line[1]), content: line[2]));
        }

        reader.Close();
        return result;
    }
}
