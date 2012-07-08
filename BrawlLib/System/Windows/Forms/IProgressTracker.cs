﻿using System;

namespace System.Windows.Forms
{
    public interface IProgressTracker
    {
        //void SetRange(float min, float max, float current);
        void Update(float value);
        void Begin(float min, float max, float current);
        void Finish();
        void Cancel();

        float MinValue { get; set; }
        float MaxValue { get; set; }
        float CurrentValue { get; set; }
        bool Cancelled { get; set; }
    }
}
