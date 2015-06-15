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
    // GoodsBill
    public class GoodsBill
    {
        public int? GoodsCode { get; set; } // GoodsCode
        public int? TypeCode { get; set; } // TypeCode
        public string Name { get; set; } // Name
        public int? Number { get; set; } // Number
        public DateTime? CreateTime { get; set; } // CreateTime
        public int BillCode { get; set; } // BillCode (Primary key)
        public int? BilType { get; set; } // BilType
    }

}
