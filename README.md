# Debug Explosions

A tiny RimWorld mod that adds stronger explosions to the **Debug Actions** menu as
clickable tools. Visible only in Development Mode; no effect during normal play.

Targets RimWorld **1.5** and **1.6**.

## What it does

Adds a **Debug Explosions** category to the debug actions menu with a set of
preset explosions. Each entry is a `ToolMap` action: click the entry, then click
the target tile to detonate there.

| Entry                          | Radius | Damage | Type  |
| ------------------------------ | ------ | ------ | ----- |
| Bomb  r10 / 1000               | 10     | 1000   | Bomb  |
| Bomb  r20 / 5000               | 20     | 5000   | Bomb  |
| Bomb  r30 / 10000              | 30     | 10000  | Bomb  |
| Bomb  r50 / 25000 (Map-Wischer)| 50     | 25000  | Bomb  |
| Flame r15 / 2000               | 15     | 2000   | Flame |
| EMP   r20 / 500                | 20     | 500    | EMP   |

Each action calls `GenExplosion.DoExplosion` at the clicked cell with a fixed
radius, damage, and damage type. Unlike the vanilla "do explosion" debug tool
(which offers radii up to ~20 and uses each damage def's default damage), these
presets reach a larger radius and apply much higher per-cell damage.

## Build

Requires the .NET SDK (`dotnet --version` to verify). From a CMD prompt:

```cmd
cd /d "C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\DebugExplosions\Source" && dotnet build -c Release
```

The first build needs network access once for the NuGet restore of the
reference assemblies. The compiled DLL lands in `Assemblies\DebugExplosions.dll`.

If your RimWorld install lives elsewhere, edit the `<RimWorldManaged>` path in
`Source\DebugExplosions.csproj` to point at your own `...\RimWorldWin64_Data\Managed`
folder.

## Install

Place the whole `DebugExplosions` folder in your RimWorld `Mods` directory (or
the AppData mods folder), enable it in the in-game mod list, turn on Development
Mode, open the debug actions menu and filter for **Debug Explosions**. Click an
entry, then click the target tile.

## Customizing the presets

The values are plain numbers in `Source\DebugExplosions.cs`. To add a tier, copy
a method block and change the label and the three arguments of
`Boom(radius, damage, type)`. Available damage types include `DamageDefOf.Bomb`,
`DamageDefOf.Flame`, `DamageDefOf.EMP`, and `DamageDefOf.Stun`.

## Version note

Written for 1.5/1.6 (`using LudeonTK;`). For 1.4 and older, replace
`using LudeonTK;` with `using Verse;` in `DebugExplosions.cs` — the debug
classes moved to the `LudeonTK` namespace only as of 1.5.

## License

MIT — see [LICENSE](LICENSE).
