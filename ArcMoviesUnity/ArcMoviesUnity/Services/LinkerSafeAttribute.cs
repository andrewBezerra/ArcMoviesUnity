using ArcMoviesUnity.Droid;
using System;

namespace ArcMoviesUnity.Droid
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class PreserveAttribute : Attribute
    {
        public bool AllMembers { get; set; }
       
        public bool Conditional{get; set;}

        public PreserveAttribute()
        {

        }
    }
}
