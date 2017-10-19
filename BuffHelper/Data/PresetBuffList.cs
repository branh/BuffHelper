namespace BuffHelper.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class PresetBuffList
    {
        public static IReadOnlyList<Buff> DefaultConditionList;

        private static List<Modifier> _EmptyList = new List<Modifier>();

        static PresetBuffList()
        {
            PresetBuffList.DefaultConditionList = PresetBuffList.DefaultConditions();
        }

        public static List<Buff> DefaultConditions()
        {
            List<Buff> result = new List<Buff>();
            Modifier[] blindModifiers = { new Modifier(-2, StatTypes.BaseAC),
                                          new Modifier(-4, StatTypes.Perception),
                                          new Modifier(-4, StatTypes.Climb),
                                          new Modifier(-4, StatTypes.Swim),
                                          new Modifier(-4, StatTypes.Acrobatics),
                                          new Modifier(-4, StatTypes.DisableDevice),
                                          new Modifier(-4, StatTypes.EscapeArtist),
                                          new Modifier(-4, StatTypes.Fly),
                                          new Modifier(-4, StatTypes.Ride),
                                          new Modifier(-4, StatTypes.SlightHand),
                                          new Modifier(-4, StatTypes.Stealth) };
            result.Add(new Buff("Blinded", BuffType.Bane, blindModifiers));

            result.Add(new Buff("Confused", BuffType.Bane, PresetBuffList._EmptyList));

            Modifier[] cowerModifiers = { new Modifier(-2, StatTypes.BaseAC) };
            result.Add(new Buff("Cower", BuffType.Bane, cowerModifiers));

            result.Add(new Buff("Dazed", BuffType.Bane, PresetBuffList._EmptyList));

            Modifier[] dazzledModifiers = { new Modifier(-1, StatTypes.MeleeHit),
                                            new Modifier(-1, StatTypes.RangedHit),
                                            new Modifier(-1, StatTypes.Perception) };
            result.Add(new Buff("Dazzled", BuffType.Bane, dazzledModifiers));

            Modifier[] deafenedModifiers = { new Modifier(-4, StatTypes.Init),
                                             new Modifier(-4, StatTypes.Perception) };
            result.Add(new Buff("Deafened", BuffType.Bane, deafenedModifiers));

            Modifier[] entangledModifiers = { new Modifier(-2, StatTypes.MeleeHit),
                                              new Modifier(-2, StatTypes.RangedHit),
                                              new Modifier(-4, StatTypes.Dex) };
            result.Add(new Buff("Entangled", BuffType.Bane, entangledModifiers));

            Modifier[] exhaustedModifiers = { new Modifier(-6, StatTypes.Str),
                                              new Modifier(-6, StatTypes.Dex)};
            result.Add(new Buff("Exhausted", BuffType.Bane, exhaustedModifiers));

            Modifier[] fascinatedModifiers = { new Modifier(-4, StatTypes.Perception) };
            result.Add(new Buff("Fascinated", BuffType.Bane, fascinatedModifiers));

            Modifier[] fatiguedModifiers = { new Modifier(-2, StatTypes.Str),
                                             new Modifier(-2, StatTypes.Dex) };
            result.Add(new Buff("Fatigued", BuffType.Bane, fatiguedModifiers));

            List<Modifier> frightenedModifiers = new List<Modifier>();
            frightenedModifiers.AddRange(StatTypes.ModifyAllAttackRolls(-2));
            frightenedModifiers.AddRange(StatTypes.ModifyAllSaves(-2));
            frightenedModifiers.Add(new Modifier(-2, StatTypes.Skill));
            result.Add(new Buff("Freightened", BuffType.Bane, frightenedModifiers));

            Modifier[] grappledModifiers = { new Modifier(-4, StatTypes.Dex),
                                             new Modifier(-2, StatTypes.MeleeHit),
                                             new Modifier(-2, StatTypes.RangedHit),
                                             new Modifier(-2, StatTypes.CMB) };
            result.Add(new Buff("Grappled", BuffType.Bane, grappledModifiers));

            Modifier[] invisibleModifiers = { new Modifier(2, StatTypes.MeleeHit, ModifierTypes.Untyped),
                                              new Modifier(2, StatTypes.RangedHit, ModifierTypes.Untyped) };
            result.Add(new Buff("Invisibile", BuffType.Bane, invisibleModifiers));

            // TODO: Add Panicked and beyond.
            List<Modifier> panickedModifiers = new List<Modifier>();
            panickedModifiers.AddRange(StatTypes.ModifyAllSaves(-2));
            panickedModifiers.Add(new Modifier(-2, StatTypes.Skill));
            result.Add(new Buff("Panicked", BuffType.Bane, panickedModifiers));

            Modifier[] pinnedModifiers = { new Modifier(-4, StatTypes.BaseAC) };
            result.Add(new Buff("Pinned", BuffType.Bane, pinnedModifiers));

            Modifier[] proneModifiers = { new Modifier(-4, StatTypes.MeleeHit) };
            // TODO: Add +4 to ranged AC, -4 to melee AC
            result.Add(new Buff("Prone", BuffType.Bane, proneModifiers));

            List<Modifier> shakenModifiers = new List<Modifier>();
            shakenModifiers.AddRange(StatTypes.ModifyAllAttackRolls(-2));
            shakenModifiers.AddRange(StatTypes.ModifyAllSaves(-2));
            shakenModifiers.Add(new Modifier(-2, StatTypes.Skill));
            result.Add(new Buff("Shaken", BuffType.Bane, shakenModifiers));

            List<Modifier> sickenedModifiers = new List<Modifier>();
            sickenedModifiers.AddRange(StatTypes.ModifyAllAttackRolls(-2));
            sickenedModifiers.AddRange(StatTypes.ModifyAllDamageRolls(-2));
            sickenedModifiers.AddRange(StatTypes.ModifyAllSaves(-2));
            sickenedModifiers.Add(new Modifier(-2, StatTypes.Skill));
            result.Add(new Buff("Sickened", BuffType.Bane, sickenedModifiers));

            result.Add(new Buff("Staggered", BuffType.Bane, PresetBuffList._EmptyList));

            Modifier[] stunnedModifiers = { new Modifier(-2, StatTypes.BaseAC) };
            result.Add(new Buff("Stunned", BuffType.Bane, stunnedModifiers));
            return result;
        }
    }
}
