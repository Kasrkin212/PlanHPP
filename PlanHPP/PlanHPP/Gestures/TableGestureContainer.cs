﻿
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace PlanHPP.Gestures
{

    public class TableGestureContainer : ContentView, INotifyPropertyChanged
    {
        private double _startScale, _currentScale;
        private double _startX, _startY;
        private double _xOffset, _yOffset;
        double maxTranslationY;
        double maxTranslationX;
        public double MinScale { get; set; } = 1;
        public double MaxScale { get; set; } = 4;

        public TableGestureContainer()
        {
            
            var tap = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
            tap.Tapped += OnTapped;
            GestureRecognizers.Add(tap);

            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinchGesture);

            var pan = new PanGestureRecognizer();
            pan.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(pan);

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            RestoreScaleValues();
            Content.AnchorX = 0.5;
            Content.AnchorY = 0.5;

            base.OnSizeAllocated(width, height);
        }

        private void RestoreScaleValues()
        {
            Content.ScaleTo(MinScale, 250, Easing.CubicInOut);
            Content.TranslateTo(0, 0, 250, Easing.CubicInOut);

            _currentScale = MinScale;
            _xOffset = Content.TranslationX = 0;
            _yOffset = Content.TranslationY = 0;
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (Content.Scale > MinScale)
            {
                RestoreScaleValues();
            }
            else
            {
                //todo: Add tap position somehow
                StartScaling();
                ExecuteScaling(MaxScale, .5, .5);
                EndGesture();
            }
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            switch (e.Status)
            {
                case GestureStatus.Started:
                    StartScaling();

                    break;

                case GestureStatus.Running:
                    ExecuteScaling(e.Scale, e.ScaleOrigin.X, e.ScaleOrigin.Y);
                    break;

                case GestureStatus.Completed:
                    EndGesture();
                    break;
            }
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    _xOffset = Content.TranslationX;
                    _yOffset = Content.TranslationY;
                    _startX = e.TotalX;
                    _startY = e.TotalY;

                    Content.AnchorX = 0;
                    Content.AnchorY = 0;

                    break;

                case GestureStatus.Running:
                    if (Content.Scale == 1)
                    {
                        maxTranslationX = Content.Scale * (Content.Width - App.ScreenWidth);
                        Content.TranslationX = Math.Min(0, Math.Max(-maxTranslationX, _xOffset + e.TotalX - _startX));
                    }

                    else
                    {
                        maxTranslationX = Content.Scale * Content.Width - App.ScreenWidth;
                        Content.TranslationX = Math.Min(0, Math.Max(-maxTranslationX, _xOffset + e.TotalX - _startX));
                    }



                    if (Content.Scale == 1)
                    {
                        maxTranslationY = Content.Scale * (Content.Height - App.ScreenHeight / 2);
                        Content.TranslationY = Math.Min(0, Math.Max(-maxTranslationY, _yOffset + e.TotalY - _startY));
                    }

                    else
                    {
                        maxTranslationY = Content.Scale * Content.Height - App.ScreenHeight / 2;
                        Content.TranslationY = Math.Min(0, Math.Max(-maxTranslationY, _yOffset + e.TotalY - _startY));
                    }




                    break;

                case GestureStatus.Completed:
                    EndGesture();
                    break;
            }
        }

        private void StartScaling()
        {
            _xOffset = Content.TranslationX;
            _yOffset = Content.TranslationY;
            _startScale = Content.Scale;
            _currentScale = Content.Scale;

            Content.AnchorX = 0;
            Content.AnchorY = 0;
        }

        private void ExecuteScaling(double scale, double x, double y)
        {


            _currentScale += (scale - 1) * _startScale;
            _currentScale = Math.Max(MinScale, _currentScale);
            _currentScale = Math.Min(MaxScale, _currentScale);

            var deltaX = (Content.X + _xOffset) / Width;
            var deltaWidth = Width / (Content.Width * _startScale);
            var originX = (x - deltaX) * deltaWidth;

            var deltaY = (Content.Y + _yOffset) / Height;
            var deltaHeight = Height / (Content.Height * _startScale);
            var originY = (y - deltaY) * deltaHeight;

            var targetX = _xOffset - (originX * Content.Width) * (_currentScale - _startScale);
            var targetY = _yOffset - (originY * Content.Height) * (_currentScale - _startScale);

            Content.TranslationX = targetX.Clamp(-Content.Width * _currentScale, 0);
            Content.TranslationY = targetY.Clamp(-Content.Height * _currentScale, 0);

            Content.Scale = _currentScale;
        }

        private void EndGesture()
        {
            _xOffset = Content.TranslationX;
            _yOffset = Content.TranslationY;
        }
        
    }

}
