﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudioApplication
{
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtCourse.Clear();
            txtName.Clear();
            txtPhone.Clear();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {

        }
    }
}