using System;

namespace CqrsIntroduction
{
    public class NameId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Equals(NameId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id) && Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NameId)) return false;
            return Equals((NameId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode()*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}