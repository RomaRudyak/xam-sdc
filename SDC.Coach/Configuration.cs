using System;

using SDC.Coach.Helpers;

namespace SDC.Coach
{
    public static class Configuration
    {
        public static String GoogleClientIdiOS { get; } = Secrets.GoogleClientIdiOS;
        public static String GoogleClientIdDroid { get; } = Secrets.GoogleClientIdDroid;
    }
}
