namespace ctaskmaster.Models
{
  public class Tasky
  {
    public int Id {get;set;}
    public string Body {get;set;}
  }

  public class TaskListViewModel : Tasky
  {
    public int TaskListId {get;set;}
  }
}