using System;

using SDC.Coach.Helpers;

namespace SDC.Coach
{
    public static class Configuration
    {
        public static String ClientId { get; } = Secrets.GoogleClientId;
    }
}
