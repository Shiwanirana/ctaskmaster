using System;

namespace ctaskmaster
{
  public class NotAuthorized : Exception
  {
    public NotAuthorized(string message) : base(message)
    {
      
    }
  }
}