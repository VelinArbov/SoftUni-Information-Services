﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MVCFramework.Tests
{
    public class TestViewModel
    {

        public int Year { get; set; }


        public string Name { get; set; }


        public IEnumerable<int> Numbers { get; set; }
    }
}
