using RimWorld;
using System.Linq;
using Verse;

public class MapComponent_ILikeBuildBase : MapComponent
{
    public MapComponent_ILikeBuildBase(Map map) : base(map)
    {
#if DEBUG
        Log.Message("MapComponent_ILikeBuildBase constructor called");
#endif
    }

    public override void MapComponentTick()
    {
        if (map.IsHashIntervalTick(1200))
        {
            Storyteller storyteller = Find.Storyteller;
            if (storyteller.def.defName == "ILikeBuildBase")
            {
                float wealthPerPawn = map.PlayerWealthForStoryteller / map.PlayerPawnsForStoryteller.Count();
                storyteller.def.populationIntentFactorFromPopCurve =
                [
                    new CurvePoint(0f, wealthPerPawn),
                    new CurvePoint(50f, wealthPerPawn / 5f),
                    new CurvePoint(100f, 0f)
                ];
            }
        }
        base.MapComponentTick();
    }
}
