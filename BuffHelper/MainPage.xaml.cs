namespace BuffHelper
{
    using System.Collections.Generic;
    using BuffHelper.Data;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Model Model = new Model();

        public MainPage()
        {
            this.PopulateBuffs();
            this.Model.CalculateAllModifiers();
            this.InitializeComponent();
        }

        private void PopulateBuffs()
        {
            Modifier[] blindModifiers = { new Modifier(-2, StatType.AC),
                                          new Modifier(-4, StatType.Skill) };
            this.Model.AddBuff(new Buff("Blinded", BuffType.Bane, blindModifiers));

            this.Model.AddBuff(new Buff("Confused", BuffType.Bane, new List<Modifier>()));

            Modifier[] cowerModifiers = { new Modifier(-2, StatType.AC) };
            this.Model.AddBuff(new Buff("Cower", BuffType.Bane, cowerModifiers));

            Modifier[] dazzledModifiers = { new Modifier(-1, StatType.MeleeHit),
                                            new Modifier(-1, StatType.RangedHit),
                                            new Modifier(-1, StatType.Skill) };
            this.Model.AddBuff(new Buff("Dazzled", BuffType.Bane, dazzledModifiers));

            Modifier[] deafenedModifiers = { new Modifier(-4, StatType.Initiative),
                                             new Modifier(-4, StatType.Skill) };
            this.Model.AddBuff(new Buff("Deafened", BuffType.Bane, deafenedModifiers));

            Modifier[] entangledModifiers = { new Modifier(-2, StatType.MeleeHit),
                                              new Modifier(-2, StatType.RangedHit),
                                              new Modifier(-4, StatType.Dex) };
            this.Model.AddBuff(new Buff("Entangled", BuffType.Bane, entangledModifiers));

            Modifier[] exhaustedModifiers = { new Modifier(-6, StatType.Str),
                                              new Modifier(-6, StatType.Dex)};
            this.Model.AddBuff(new Buff("Exhausted", BuffType.Bane, exhaustedModifiers));

            Modifier[] fascinatedModifiers = { new Modifier(-4, StatType.Skill) };
            this.Model.AddBuff(new Buff("Fascinated", BuffType.Bane, fascinatedModifiers));

            Modifier[] fatiguedModifiers = { new Modifier(-2, StatType.Str),
                                             new Modifier(-2, StatType.Dex) };
            this.Model.AddBuff(new Buff("Fatigued", BuffType.Bane, fatiguedModifiers));

            Modifier[] frightenedModifiers = { new Modifier(-2, StatType.MeleeHit),
                                               new Modifier(-2, StatType.RangedHit),
                                               new Modifier(-2, StatType.Fort),
                                               new Modifier(-2, StatType.Ref),
                                               new Modifier(-2, StatType.Will),
                                               new Modifier(-2, StatType.Skill) };
            this.Model.AddBuff(new Buff("Freightened", BuffType.Bane, frightenedModifiers));

            Modifier[] grappledModifiers = { new Modifier(-4, StatType.Dex),
                                              new Modifier(-2, StatType.MeleeHit),
                                              new Modifier(-2, StatType.RangedHit),
                                              new Modifier(-2, StatType.CMB) };
            this.Model.AddBuff(new Buff("Grappled", BuffType.Bane, grappledModifiers));

            Modifier[] invisibleModifiers = { new Modifier(2, StatType.MeleeHit, ModifierType.Untyped) };
            this.Model.AddBuff(new Buff("Invisibile", BuffType.Bane, invisibleModifiers));

            // TODO: Add Panicked and beyond.
        }
    }
}
