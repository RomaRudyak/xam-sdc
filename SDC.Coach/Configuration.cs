using System;

using SDC.Coach.Helpers;

namespace SDC.Coach
{
    public static class Configuration
    {
        public static String GoogleClientIdiOS { get; } = AppendGoogleClientSamePart(Secrets.GoogleClientIdiOS);
        public static String GoogleClientIdDroid { get; } = AppendGoogleClientSamePart(Secrets.GoogleClientIdDroid);

        private static String AppendGoogleClientSamePart(String googleId) => $"{googleId}.apps.googleusercontent.com";
    }
}
