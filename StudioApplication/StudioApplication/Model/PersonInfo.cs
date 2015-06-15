// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.5

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace StudioApplication.Model
{
    // PersonInfo
    public class PersonInfo
    {
        public string Name { get; set; } // Name
        public string Phone { get; set; } // Phone
        public string Address { get; set; } // Address
        public string Code { get; set; } // Code (Primary key)
        public int Type { get; set; } // Type 0:student,1:teacher
    }

}
