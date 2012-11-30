﻿using System;

namespace BrawlLib.Imaging
{
    public interface IColorSource
    {
        bool HasPrimary(int id);
        ARGBPixel GetPrimaryColor(int id);
        void SetPrimaryColor(int id, ARGBPixel color);
        string PrimaryColorName(int id);

        int ColorCount(int id);
        ARGBPixel GetColor(int index, int id);
        void SetColor(int index, int id, ARGBPixel color);
    }
}
