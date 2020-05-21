using System;

namespace Exercises._04_Collections
{
    public class Permission : IEquatable<Permission>
    {
        public string Code { get; }

        public Permission(string code) => Code = code;

        public bool Equals(Permission other) => other != null && Code == other.Code;

        public override bool Equals(object obj) => obj is Permission other && Equals(other);

        public override int GetHashCode() => Code != null ? Code.GetHashCode() : 0;
    }
}