// List "using" statements first.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Now list any assembly- or module-level attributes.
// Enforce CLS compliance for all public types in this assembly.
[assembly: CLSCompliant(true)]

namespace AttributedCarLibrary
{
    // This time, we are using the AttributeUsage attribute
    // to annotate our custom attribute.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,
                    Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }
        public VehicleDescriptionAttribute() { }
    }

    // Assign description using a "named property."
    [Serializable]
    [VehicleDescription(Description = "My rocking Harley")]
    public class Motorcycle
    {
    }

    [SerializableAttribute]
    [ObsoleteAttribute("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy
    {
    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
        // Ulong types don't jibe with the CLS.
        public ulong notCompliant;

        public void PlayMusic(bool On)
        {
        
        }
    }

}
