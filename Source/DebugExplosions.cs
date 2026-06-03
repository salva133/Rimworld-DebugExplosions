using LudeonTK;
using RimWorld;
using Verse;

namespace DebugExplosions
{
    // Alle Eintraege landen im Debug-Actions-Menue unter der Kategorie "Debug Explosions".
    // Jede Aktion ist ein ToolMap: anklicken, dann auf das Ziel-Tile klicken.
    public static class DebugExplosionsActions
    {
        private const string Category = "Debug Explosions";

        private static void Boom(float radius, int damage, DamageDef damType)
        {
            Map map = Find.CurrentMap;
            if (map == null) return;

            IntVec3 cell = UI.MouseCell();
            if (!cell.InBounds(map)) return;

            GenExplosion.DoExplosion(cell, map, radius, damType, null, damage);
        }

        [DebugAction(Category, "Bomb  r10 / 1000",
            actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Bomb10() => Boom(10f, 1000, DamageDefOf.Bomb);

        [DebugAction(Category, "Bomb  r20 / 5000",
            actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Bomb20() => Boom(20f, 5000, DamageDefOf.Bomb);

        [DebugAction(Category, "Bomb  r30 / 10000",
            actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Bomb30() => Boom(30f, 10000, DamageDefOf.Bomb);

        [DebugAction(Category, "Bomb  r50 / 25000 (Map-Wischer)",
            actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Bomb50() => Boom(50f, 25000, DamageDefOf.Bomb);

        [DebugAction(Category, "Flame r15 / 2000",
            actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Flame15() => Boom(15f, 2000, DamageDefOf.Flame);

        [DebugAction(Category, "EMP   r20 / 500",
            actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void Emp20() => Boom(20f, 500, DamageDefOf.EMP);
    }
}
