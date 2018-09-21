using System;
using System.Drawing;

namespace MattLamp.Common
{
    public static class ColorUtils
    {
        /// <summary>
        /// Creates a Color from alpha, hue, saturation and brightness.
        /// </summary>
        /// <param name="hue">The hue value.</param>
        /// <param name="saturation">The saturation value.</param>
        /// <param name="brightness">The brightness value.</param>
        /// <param name="alpha">The alpha channel value.</param>
        /// <returns>A Color with the given values.</returns>
        public static Color FromHSB(float hue, float saturation, float brightness, int alpha = 0xFF)
        {
            if (0 > alpha || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException("alpha", alpha, "Value must be within a range of 0 - 255.");
            }

            if (0f > hue || 360f < hue)
            {
                throw new ArgumentOutOfRangeException("hue", hue, "Value must be within a range of 0 - 360.");
            }

            if (0f > saturation || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException("saturation", saturation, "Value must be within a range of 0 - 1.");
            }

            if (0f > brightness || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException("brightness", brightness, "Value must be within a range of 0 - 1.");
            }

            if (0 == saturation)
            {
                // Gray
                return Color.FromArgb(alpha, Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }

            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = (hue * (fMax - fMin)) + fMin;
            }
            else
            {
                fMid = fMin - (hue * (fMax - fMin));
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(alpha, iMax, iMid, iMin);
            }
        }

        /// <summary>
        /// Given a temperature (in Kelvin), estimate an RGB equivalent
        /// </summary>
        /// <param name="tempK">Color temperature in degrees Kelvin</param>
        /// <remarks>
        /// This method converted from Visual Basic from here:
        /// http://www.tannerhelland.com/4435/convert-temperature-rgb-algorithm-code/
        /// </remarks>
        /// <returns>System.Drawing.Color structure</returns>
        public static Color FromTemperatureK(float tempK)
        {
            byte r, g, b;

            // Temperature must fall between 1000 and 40000 degrees
            if (tempK < 1000) tempK = 1000;
            if (tempK > 40000) tempK = 40000;

            // All calculations require tmpKelvin \ 100, so only do the conversion once
            tempK = tempK / 100;

            // Calculate red
            if (tempK <= 66) r = 0xFF;
            else
            {
                // Note: the R-squared value for this approximation is .988
                double rCalc = 329.698727446 * Math.Pow(tempK - 60, -0.1332047592);
                if (rCalc < 0) r = 0;
                if (rCalc > 255) r = 255;
                else r = (byte)rCalc;
            }

            // Calculate green
            if (tempK <= 66)
            {
                // Note: the R-squared value for this approximation is .996
                double gCalc = 99.4708025861 * Math.Log(tempK) - 161.1195681661;
                if (gCalc < 0) g = 0;
                if (gCalc > 255) g = 255;
                else g = (byte)gCalc;
            }
            else
            {
                // Note: the R-squared value for this approximation is .987
                double gCalc = 288.1221695283 * Math.Pow(tempK - 60, -0.0755148492);
                if (gCalc < 0) g = 0;
                if (gCalc > 255) g = 255;
                else g = (byte)gCalc;
            }

            // Calculate blue
            if (tempK >= 66) b = 255;
            else if (tempK <= 19) b = 0;
            else
            {
                // Note: the R-squared value for this approximation is .998
                double bCalc = 138.5177312231 * Math.Log(tempK - 10) - 305.0447927307;
                if (bCalc < 0) b = 0;
                if (bCalc > 255) b = 255;
                else b = (byte)bCalc;
            }

            return Color.FromArgb(r, g, b);
        }
    }
}
