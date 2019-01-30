using System;

namespace FactoryMethod_Demo
{
    class Kantine
    {
        public IEssen GibEssen()
        {
            return GibEssen(DateTime.Now);
        }

        public IEssen GibEssen (DateTime time)
        {
            switch (time.Hour)
            {
                case int h when h >= 6 && h < 11:
                    return new Frühstück();
                case int h when h >= 11 && h < 16:
                    return new Mittagessen();
                case int h when h >= 16 && h < 22:
                    return new Abendessen();
                default:
                    return new KeinEssen();
            }
        }
    }
}
