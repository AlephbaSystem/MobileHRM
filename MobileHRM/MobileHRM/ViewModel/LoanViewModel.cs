using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class LoanViewModel : Base
    {
        private string loandNextPay { get; set; }
        private string nextLoanAmount { get; set; }
        private string chance { get; set; }
        private string riyalinThebox { get; set; }
        private string participant { get; set; }

        public string NextLoanAmount
        {
            get
            {
                return nextLoanAmount;
            }
            set
            {
                nextLoanAmount = value;
                OnPropertyChanged(nameof(NextLoanAmount));
            }
        }
        public string LoandNextPay
        {
            get
            {
                return loandNextPay;
            }
            set
            {
                loandNextPay = value;
                OnPropertyChanged(nameof(LoandNextPay));
            }
        }

        public string Chance
        {
            get
            {
                return chance;
            }
            set
            {
                chance = value;
                OnPropertyChanged(nameof(Chance));
            }
        }

        public string RiyalinThebox
        {
            get
            {
                return riyalinThebox;
            }
            set
            {
                riyalinThebox = value;
                OnPropertyChanged(nameof(RiyalinThebox));
            }
        }
        public string Participant
        {
            get
            {
                return participant;
            }
            set
            {
                participant = value;
                OnPropertyChanged(nameof(Participant));
            }
        }

    }
}
