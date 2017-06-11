namespace BuffHelper
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using BuffHelper.Data;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<ActivatableBuff> buffs = new ObservableCollection<ActivatableBuff>();

        public MainPage()
        {
            List<Modifier> buffModifiers = new List<Modifier>();
            buffModifiers.Add(new Modifier(2, ModifierType.Competence, StatType.Skill));
            this.buffs.Add(new ActivatableBuff(new Buff("Inspire Competence", BuffType.Buff, buffModifiers)));
            this.buffs.Add(new ActivatableBuff(new Buff("Inspire Courage", BuffType.Neutral, new List<Modifier>())));
            this.InitializeComponent();
        }
    }
}
