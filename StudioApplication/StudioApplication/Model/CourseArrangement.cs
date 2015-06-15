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
    // CourseArrangement ее©н
    public class CourseArrangement
    {
        public string CourseCode { get; set; } // CourseCode
        public DateTime? CourseTime { get; set; } // CourseTime
        public string TeacherCode { get; set; } // TeacherCode
        public int Code { get; set; } // Code (Primary key)
        public bool? CheckIn { get; set; } // CheckIn

        public CourseArrangement()
        {
            CheckIn = false;
        }
    }

}
