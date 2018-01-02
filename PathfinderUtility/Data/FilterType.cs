namespace Pathfinder.Utility.Data
{
    public interface FilterType
    {
        string FilterName { get; }
        bool Filter(ActivatableBuff buff);
    }

    public class NoFilter : FilterType
    {
        public string FilterName
        {
            get
            {
                return "None";
            }
        }

        public bool Filter(ActivatableBuff buff)
        {
            return true; 
        }

        private NoFilter() { }

        private static NoFilter instance = new NoFilter();
        public static NoFilter Instance
        {
            get
            {
                return NoFilter.instance;
            }
        }
    }

    public class ActiveFilter : FilterType
    {
        public string FilterName
        {
            get
            {
                return "Active";
            }
        }

        public bool Filter(ActivatableBuff buff)
        {
            return buff.IsActive;
        }

        private ActiveFilter() { }

        private static ActiveFilter instance = new ActiveFilter();
        public static ActiveFilter Instance
        {
            get
            {
                return ActiveFilter.instance;
            }
        }
    }

    public class BuffFilter : FilterType
    {
        public string FilterName
        {
            get
            {
                return "Buff";
            }
        }

        public bool Filter(ActivatableBuff buff)
        {
            return buff.Buff.BuffType == BuffType.Buff;
        }

        private BuffFilter() { }

        private static BuffFilter instance = new BuffFilter();
        public static BuffFilter Instance
        {
            get
            {
                return BuffFilter.instance;
            }
        }
    }

    public class BaneFilter : FilterType
    {
        public string FilterName
        {
            get
            {
                return "Bane";
            }
        }

        public bool Filter(ActivatableBuff buff)
        {
            return buff.Buff.BuffType == BuffType.Bane;
        }

        private BaneFilter() { }

        private static BaneFilter instance = new BaneFilter();
        public static BaneFilter Instance
        {
            get
            {
                return BaneFilter.instance;
            }
        }
    }
}
