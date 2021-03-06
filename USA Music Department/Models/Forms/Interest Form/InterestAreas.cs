﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USA_Music_Department.Models.Forms.Interest_Form
{
    public class InterestAreas
    {
        [Display(Name = "BM Music Education Vocal")]
        public bool BM_Music_Education_Vocal { get; set; }
        [Display(Name = "BM Music Education Instrumental")]
        public bool BM_Music_Education_Instrumental { get; set; }
        [Display(Name = "BM Music Performance Vocal")]
        public bool BM_Music_Performance_Vocal { get; set; }
        [Display(Name = "BM Music Performance Instrumental")]
        public bool BM_Music_Performance_Instrumental { get; set; }
        [Display(Name = "BM Music Elective Studies Business")]
        public bool BM_Music_Elective_Studies_Business { get; set; }
        [Display(Name = "BM Music Elective Studies Outside Fields")]
        public bool BM_Music_Elective_Studies_Outside_Fields { get; set; }
        [Display(Name = "MM Performance Piano")]
        public bool MM_Performance_Piano { get; set; }
        [Display(Name = "MM Performance Vocal")]
        public bool MM_Performance_Vocal { get; set; }
        [Display(Name = "MM Collaborative Piano")]
        public bool MM_Collaborative_Piano { get; set; }
        [Display(Name = "Music Minor")]
        public bool Music_Minor { get; set; }
        [Display(Name = "Choral Ensembles")]
        public bool Choral_Ensembles { get; set; }
        [Display(Name = "Instrumental Ensembles")]
        public bool Instrumental_Ensembles { get; set; }
        [Display(Name = "Opera Theatre")]
        public bool Opera_Theatre { get; set; }
        [Display(Name = "Jaguar Marching Band")]
        public bool Jaguar_Marching_Band { get; set; }
        public string Other { get; set; }
        [Display(Name = "MM Concentration in Music Education")]
        public bool MM_Concentration_in_Music_Education { get; set; }
    }
}