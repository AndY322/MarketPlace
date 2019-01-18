using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Constants
{
    public static class Constants
    {
        public static class Roles
        {
            public static Guid User
            {
                get
                {
                    return new Guid("d39080d6-4bfd-4caf-add3-0393d012990f");
                }
            }

            public static Guid Admin
            {
                get
                {
                    return new Guid("15355d00-a37a-4226-8da4-99280d7337fe");
                }
            }
        }
    }
}