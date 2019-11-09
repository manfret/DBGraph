using System.Collections.Generic;

namespace MyGraph.Field
{
    public class FieldComparer : IEqualityComparer<IField>
    {
        public bool Equals(IField f1, IField f2)
        {
            return (f1.SelectKey.Equals(f2.SelectKey));
        }

        public int GetHashCode(IField f)
        {
            int hash = 1;
            hash *= f.SelectKey.GetHashCode();
            return hash;
        }

    }
}