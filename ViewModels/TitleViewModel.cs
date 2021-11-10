﻿using System;
namespace Raw5MovieDb_WebApi.ViewModels
{
    public class TitleViewModel
    {
        public string Url { get; set; }
        public string Titletype { get; set; }
        public string Primarytitle { get; set; }
        public string Originaltitle { get; set; }
        public bool Isadult { get; set; }
        public string Startyear { get; set; }
        public string Endyear { get; set; }
        public int Runtimeminutes { get; set; }
    }
}
