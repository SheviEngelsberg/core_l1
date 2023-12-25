using myTask.Models;
namespace myTask.Services;

public static class theTaskService
{
    private static List<theTask> tasks;

    static theTaskService()
    {
        tasks = new List<theTask>
        {
            new theTask { Id = 1, Name = "homework", IsDone = false},
            new theTask { Id = 2, Name = "bake a cake", IsDone = false},
            new theTask { Id = 3, Name = "wosh the room", IsDone = true}
        };
    }

    public static List<theTask> GetAll() => tasks;

    public static theTask GetById(int id) 
    {
        return tasks.FirstOrDefault(p => p.Id == id);
    }

    public static int Add(theTask newTask)
    {
        if (tasks.Count == 0)

            {
                newTask.Id = 1;
            }
            else
            {
        newTask.Id =  tasks.Max(p => p.Id) + 1;

            }

        tasks.Add(newTask);

        return newTask.Id;
    }
  
    public static bool Update(int id, theTask newTask)
    {
        if (id != newTask.Id)
            return false;

        var existingTask = GetById(id);
        if (existingTask == null )
            return false;

        var index = tasks.IndexOf(existingTask);
        if (index == -1 )
            return false;

        tasks[index] = newTask;

        return true;
    }  

      
    public static bool Delete(int id)
    {
        var existingTask = GetById(id);
        if (existingTask == null )
            return false;

        var index = tasks.IndexOf(existingTask);
        if (index == -1 )
            return false;

        tasks.RemoveAt(index);
        return true;
    }  



}