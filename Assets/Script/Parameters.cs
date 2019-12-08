namespace Script
{
    static class Parameters{
        public static int Score = 0;
        public static int KillCount = 0;
        public static int Lives = 5;
        public static float RemaindTime = 0f;
        public static float initialTime = -1f;
        internal static void Reset(){
            Parameters.Score = 0;
            Parameters.KillCount = 0;
            Parameters.Lives = 5;
            Parameters.RemaindTime = 0f;
        }
    }
}