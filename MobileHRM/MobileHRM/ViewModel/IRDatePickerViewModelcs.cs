using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using MobileHRM.Enums;
using PersianDate;
using PersianDate.Standard;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    class IRDatePickerViewModel : Base
    {        
        private readonly ObservableCollection<string> wheelMonth, wheelYear;
        private ObservableCollection<string> wheelDay;
        private DateTime selectedDate;
        private IList<int> selectedItemsIndex;
        private IList<ObservableCollection<string>> itemsSource;

        //TODO
        private readonly DateTime MaxDate = DateTime.Now.AddYears(10);
        private readonly DateTime MinDate = new DateTime(1900, 1, 1);

        public IList<ObservableCollection<string>> ItemsSource
        {
            get => itemsSource;
            set { itemsSource = value; OnPropertyChanged(); }
        }
        public IRDatePickerEnums DisplayType { get; }
        public Command<(int, int, IList<int>)> ItemSelectedCommand { get; }

        public IList<int> SelectedItemsIndex
        {
            get => selectedItemsIndex;
            set { selectedItemsIndex = value; OnPropertyChanged(); }
        }

        public DateTime SelectedDate
        {
            get => selectedDate;
            set => SetSelectedDateExternal(value);
        }
        private string GetMonthName(int month)
        {
            var MonthNames = new string[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            return MonthNames[month - 1];
        }
        public IRDatePickerViewModel(DateTime currentTime, Enums.IRDatePickerEnums displayType = Enums.IRDatePickerEnums.DayMonthYear)
        {
            try
            {
                DisplayType = displayType;

                var pc = new PersianCalendar();
                var MinYear = pc.GetYear(MinDate);
                var MaxYear = pc.GetYear(MaxDate);
                var cty = pc.GetYear(currentTime);
                var ctm = pc.GetMonth(currentTime);

                var MaxDay = pc.GetDaysInMonth(cty, ctm);

                wheelYear = new ObservableCollection<string>(Enumerable.Range(MinYear, MaxYear - MinYear + 1).Reverse().Select(year => year.ToString()));
                wheelMonth = new ObservableCollection<string>(Enumerable.Range(1, 12).Select(month => GetMonthName(month)));
                wheelDay = new ObservableCollection<string>(Enumerable.Range(1, MaxDay).Select(day => day.ToString()));

                selectedDate = currentTime;
                switch (DisplayType)
                {
                    case IRDatePickerEnums.DayMonthYear:
                        ItemsSource = new[] { wheelDay, wheelMonth, wheelYear };
                        break;
                    case IRDatePickerEnums.DayMonth:
                        ItemsSource = new[] { wheelDay, wheelMonth };
                        break;
                    case IRDatePickerEnums.Day:
                        ItemsSource = new[] { wheelDay };
                        break;
                }

                ItemSelectedCommand = new Command<(int, int, IList<int>)>(tuple =>
                {
                    var (selectedWheelIndex, selectedItemIndex, selectedItemsIndexes) = tuple;
                    if (selectedItemIndex < 0 || selectedItemsIndexes[selectedWheelIndex] < selectedItemIndex) return;
                    //After the selection has changed, update the SelectedDate string 
                    UpdateDaysFromMonthYear(selectedItemsIndexes);
                });

                //Set the initial selection
                SetSelectedDateExternal(selectedDate);
            }
            catch (Exception ex)
            {
 
            }
        }
        public void SetSelectedDateExternal(DateTime date)
        {
            try
            {
                var pc = new PersianCalendar();
                if (date < MinDate)
                    date = MinDate;
                if (date > MaxDate)
                    date = MaxDate;
                selectedDate = date;

                List<int> selection = null;
                var mdj = pc.GetYear(MaxDate);
                var ddj = pc.GetYear(date);
                var fullSelection = new List<int> { pc.GetDayOfMonth(date) - 1, pc.GetMonth(date) - 1, (mdj - ddj) };

                switch (DisplayType)
                {
                    case IRDatePickerEnums.DayMonthYear:
                        selection = fullSelection;
                        break;
                    case IRDatePickerEnums.DayMonth:
                        selection = fullSelection.Take(2).ToList();
                        break;
                    case IRDatePickerEnums.Day:
                        selection = fullSelection.Take(1).ToList();
                        break;
                }

                SelectedItemsIndex = selection;
                UpdateDaysFromMonthYear(fullSelection);
            }
            catch (Exception ex)
            {
 
            }
        }
        private void SetSelectedDateInternal(DateTime value)
        {
            selectedDate = value;
            OnPropertyChanged(nameof(SelectedDate));
        }

        /// <summary>
        /// If year or month changed, change the 'days' collection.
        /// ObservableCollection will notify the WheelPicker which will reflect the changes.
        /// </summary>
        private void UpdateDaysFromMonthYear(IList<int> selection)
        {
            try
            {
                var pc = new PersianCalendar();
                var MaxYear = pc.GetYear(MaxDate);

                var selectedYear = pc.GetYear(selectedDate);
                var selectedMonth = pc.GetMonth(selectedDate);
                var selectedDays = pc.GetDaysInMonth(selectedYear, selectedMonth);

                switch (DisplayType)
                {
                    case IRDatePickerEnums.DayMonthYear:
                        selectedYear = MaxYear - selection[2];
                        selectedMonth = 1 + selection[1];
                        selectedDays = 1 + selection[0];
                        break;
                    case IRDatePickerEnums.DayMonth:
                        selectedMonth = 1 + selection[1];
                        selectedDays = 1 + selection[0];
                        break;
                    case IRDatePickerEnums.Day:
                        selectedDays = 1 + selection[0];
                        break;
                }

                var MaxDay = pc.GetDaysInMonth(selectedYear, selectedMonth);
                if (MaxDay < selectedDays) selectedDays = MaxDay;
                var date = pc.ToDateTime(selectedYear, selectedMonth, selectedDays, 0, 0, 0, 0);
                if (MaxDay != wheelDay.Count)
                {
                    wheelDay = new ObservableCollection<string>(Enumerable.Range(1, MaxDay).Select(day => day.ToString()));
                    switch (DisplayType)
                    {
                        case IRDatePickerEnums.DayMonthYear:
                            ItemsSource = new[] { wheelDay, wheelMonth, wheelYear };
                            break;
                        case IRDatePickerEnums.DayMonth:
                            ItemsSource = new[] { wheelDay, wheelMonth };
                            break;
                        case IRDatePickerEnums.Day:
                            ItemsSource = new[] { wheelDay };
                            break;
                    }
                    SetSelectedDateExternal(date);
                    return;
                }
                SetSelectedDateInternal(date);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
