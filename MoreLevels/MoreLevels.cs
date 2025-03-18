using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace MoreLevels;
public class MoreLevels : IScriptMod
{
    public bool ShouldRun(string path) => path == "res://Scenes/Singletons/playerdata.gdc";

    public List<string> NewLevels = [];
    //["VOYAGER II", "VOYAGER III", "VOYAGER IV", "VOYAGER V","56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "80", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"];
    
    
    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
    {
        NewLevels.Clear();
        NewLevels = ["VOYAGER II", "VOYAGER III", "VOYAGER IV", "VOYAGER V"];
        for (int i = 56; i < NewLevels.Count; i++) NewLevels.Add(i.ToString());
        
        MultiTokenWaiter tokenWaiter = new MultiTokenWaiter([
            t => t is ConstantToken{Value: StringVariant{Value:"title_rank_50"}},
            t => t.Type is TokenType.BracketClose,
            t => t.Type is TokenType.Comma,
            t => t is ConstantToken{Value: StringVariant{Value:"quest"}},
            t => t.Type is TokenType.Colon,
            t => t.Type is TokenType.BracketOpen,
            t => t.Type is TokenType.BracketClose,
            t => t.Type is TokenType.CurlyBracketClose,
            t => t.Type is TokenType.Comma,
            t => t.Type is TokenType.Newline,
        ]);
        foreach (var token in tokens)
        {
            if (tokenWaiter.Check(token))
            {
                yield return token;
                int index = 51;
                for (int i = 0; i < NewLevels.Count; i++)
                {
                    yield return new ConstantToken(new IntVariant(index + i));
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.CurlyBracketOpen);
                    yield return new ConstantToken(new StringVariant("title"));
                    yield return new Token(TokenType.Colon);
                    yield return new ConstantToken(new StringVariant(NewLevels[i]));
                    yield return new Token(TokenType.Comma);
                    yield return new ConstantToken(new StringVariant("icon"));
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.PrPreload);
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new ConstantToken(new StringVariant("res://Assets/Textures/UI/RankBadges/rank_badges11.png"));
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Comma);
                    yield return new ConstantToken(new StringVariant("reward"));
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.BracketOpen);
                    yield return new Token(TokenType.BracketClose);
                    yield return new Token(TokenType.Comma);
                    yield return new ConstantToken(new StringVariant("quest"));
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.BracketOpen);
                    yield return new Token(TokenType.BracketClose);
                    yield return new Token(TokenType.CurlyBracketClose);
                    yield return new Token(TokenType.Comma);
                    yield return new Token(TokenType.Newline);
                }
            }
            else
            {
                yield return token;
            }
        }
    }
}