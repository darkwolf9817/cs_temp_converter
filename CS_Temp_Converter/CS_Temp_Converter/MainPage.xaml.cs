using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace CS_Temp_Converter;

public partial class MainPage : ContentPage
{
    private List<string> tempUnits = new List<string>
        { "Fahrenheit", "Celsius", "Kelvin" };

    public MainPage()
    {
        InitializeComponent();

        fromTempPicker.ItemsSource = tempUnits;
        toTempPicker.ItemsSource = tempUnits;
    }

    private void ConvertButton_Clicked(object sender, EventArgs e)
    {
        string fromUnit = fromTempPicker.SelectedItem.ToString();
        string toUnit = toTempPicker.SelectedItem.ToString();

        try
        {
            double inTemp = double.Parse(tempIn.Text);
            double convertedTemp = ConvertTemp(inTemp, fromUnit, toUnit);

            lstOut.ItemsSource = new List<string> { $"{inTemp} {fromUnit} = {convertedTemp:F2} {toUnit}" };
        }
        catch (FormatException)
        {
            lstOut.ItemsSource = new List<string> { "Invalid input. Please enter a valid number." };
        }
    }

    private double ConvertTemp(double inTemp, string fromUnit, string toUnit)
    {
        switch (fromUnit)
        {
            case "Fahrenheit":
                if (toUnit == "Celsius")
                {
                    return (inTemp - 32) * 5 / 9;
                }
                else if (toUnit == "Kelvin")
                {
                    return (inTemp - 32) * 5 / 9 + 273.15;
                }
                else
                {
                    return inTemp;
                }

                break;
            case "Celsius":
                if (toUnit == "Fahrenheit")
                {
                    return inTemp * 9 / 5 + 32;
                }
                else if (toUnit == "Kelvin")
                {
                    return inTemp + 273.15;
                }
                else
                {
                    return inTemp;
                }

                break;
            case "Kelvin":
                if (toUnit == "Fahrenheit")
                {
                    return (inTemp - 273.15) * 9 / 5 + 32;
                }
                else if (toUnit == "Celsius")
                {
                    return inTemp - 273.15;
                }
                else
                {
                    return inTemp;
                }

                break;
            default:
                return inTemp;
        }
    }
}