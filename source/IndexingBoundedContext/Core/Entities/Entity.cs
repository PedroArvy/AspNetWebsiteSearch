using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Logic.Core.Entities
{
  public abstract class Entity
  {
    public virtual Uri Uri { get; protected set; }

    public override bool Equals(object obj)
    {
      var other = obj as Entity;

      if (ReferenceEquals(other, null))
        return false;

      if (ReferenceEquals(this, other))
        return true;

      if (string.IsNullOrWhiteSpace(Uri.ToString()) || string.IsNullOrWhiteSpace(other.Uri.ToString()))
        return false;

      return Uri == other.Uri;
    }


    public static bool operator ==(Entity a, Entity b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;

      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;

      return a.Equals(b);
    }


    public static bool operator !=(Entity a, Entity b)
    {
      return !(a == b);
    }

    public override int GetHashCode()
    {
      return Uri.GetHashCode();
    }


  }

}
