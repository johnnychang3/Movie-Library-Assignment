﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library_Assignment.Models
{
    public class Show : Media
    {
        public int Season { get; set; }
        public int Episode { get; set; }
        public string Writer { get; set; }

        public override void Display()
        {
            Console.WriteLine($"{"Id:",-10}{Id}\n{"Title:",-10}{Title}\n{"Season:",-10}{Season}\n{"Episode:",-10}{Episode}\n{"Writer:",-10}{Writer}\n");
        }

        public override string ToString()
        {
            return $"{"Id:",-10}{Id}\n{"Title:",-10}{Title}\n{"Season:",-10}{Season}\n{"Episode:",-10}{Episode}\n{"Writer:",-10}{Writer}";
        }
    }
}
