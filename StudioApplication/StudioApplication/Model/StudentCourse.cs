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
    // StudentCourse
    public class StudentCourse
    {
        public int CourseACode { get; set; } // CourseACode (Primary key)
        public string StudentCode { get; set; } // StudentCode (Primary key)
        public bool CheckIn { get; set; } // CheckIn

        public StudentCourse()
        {
            CheckIn = false;
        }
    }

}
