using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    // This class can be saved to disk.
    [Serializable]
    class Motorcycle
    {
        // However, this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;

        // These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
