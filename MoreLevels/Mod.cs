using GDWeave;
using Serilog;

namespace MoreLevels;

public class Mod : IMod {
    public static Mod Instance;
    public ILogger Logger;

    public Mod(IModInterface modInterface) {
        modInterface.RegisterScriptMod(new MoreLevels());
        Instance = this;
        Logger = modInterface.Logger;
        Logger.Information("Loaded MoreLevels");
    }

    public void Dispose() {
    }
}
