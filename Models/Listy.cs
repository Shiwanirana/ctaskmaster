namespace ctaskmaster.Models
{
  public class Listy
  {
    public int Id {get;set;}
    public string CreatorId {get;set;}
    public string Title {get;set;}
    // public string Body {get;set;}
    public Profile Creator {get;set;}
  }

  public class ListProfileViewModel : Listy
  {
    public int ListProfileId {get;set;}
  }
}