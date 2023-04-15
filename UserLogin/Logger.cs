namespace UserLogin
{
    static public class Logger
    {
        static private string file = Directory
            .GetParent(Environment.CurrentDirectory)
            .Parent.Parent.FullName
            + Path.DirectorySeparatorChar + "log.txt";

        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            LoggerContext context = new LoggerContext();    
            LogEntity logEntity = new LogEntity(); 
           

            string activityLine = DateTime.Now + " - "
            + LoginValidation.currentUserUsername + " - "
            + LoginValidation.currentUserRole + " - "
            + activity + "\n";

            logEntity.date = DateTime.Now;
            logEntity.message = activityLine;
            logEntity.username = LoginValidation.currentUserUsername;
            context.Logs.Add(logEntity);

            context.SaveChanges();
            currentSessionActivities.Add(activityLine);

            if (File.Exists(file) != true)
            {
                FileStream fileStream = File.Create(file);
                fileStream.Close();
            }

            File.AppendAllText(file, activityLine);
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities =
                (from activity in currentSessionActivities
                 where activity.Contains(filter)
                 select activity).ToList();
            return filteredActivities;
        }

        static public IEnumerable<string> GetAllActivities()
        {
            IEnumerable<string> strings = null;
            if (File.Exists(file) == true)
            {
                strings = File.ReadLines(file);
            }
            return strings;
        }
    }
}
