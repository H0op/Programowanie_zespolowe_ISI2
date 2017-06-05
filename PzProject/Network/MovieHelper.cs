namespace PzProject.Network
{
    public static class MovieHelper
    {
        public static int getHours(int? runtime)
        {
            return runtime.Value % 59;
        }

        public static int getMinutes(int? runtime)
        {
            return runtime.Value - ((runtime.Value % 59) * 60);
        }
    }
}