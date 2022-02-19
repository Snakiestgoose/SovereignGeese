
using Data.Factory.Dev;

namespace Data.Factory
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DevFactory devFactory = new DevFactory();

            int userId = devFactory.GetDevUserId();

            if (userId == 0)
            {
                Console.WriteLine("Fail");
            }
            else
            {
                Console.WriteLine("Pass");
            }
        }
    }
}
