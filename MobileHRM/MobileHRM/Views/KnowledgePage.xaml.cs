﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.Models.Api;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnowledgePage : ContentPage
    {
        public KnowledgePage(KnowledgeDetail detail)
        {
            InitializeComponent();
        }
    }
}