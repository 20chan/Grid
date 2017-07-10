using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class Slider : GUI
    {
        public enum SliderBarDrawMode
        {
            Default, Material
        }
        private int _sliderWidth = 10;
        private float _minValue;
        public float MinValue
        {
            get => _minValue;
            set { _minValue = Math.Min(value, MaxValue); Value = Value; SetSliderWidth(); }
        }
        private float _maxValue;
        public float MaxValue
        {
            get => _maxValue;
            set { _maxValue = Math.Max(value, MinValue); Value = Value; SetSliderWidth(); }
        }

        private float _value;
        public float Value
        {
            get => _value;
            set => _value = MathHelper.Clamp(value, MinValue, MaxValue);
        }
        private float _moveRatio;
        public float MoveRatio { get => _moveRatio; set => _moveRatio = MathHelper.Clamp(value, 0, 1); }
        public Color BackColor { get; set; } = Color.LightGray;
        public Color SliderColor { get; set; } = Color.Gray;
        public SliderBarDrawMode DrawMode { get; set; } = SliderBarDrawMode.Default;

        private Rectangle _sliderBound;
        private bool _isDragging = false;
        private int _dx;

        public Slider(int x, int y, int width, int height, int min, int max, float moveRatio = 0.04f)
        {
            X = x; Y = y; Width = width; Height = height;
            MinValue = min;
            MaxValue = max;
            MoveRatio = moveRatio;
        }

        private void SetSliderWidth()
        {
            _sliderWidth = Math.Max(10, (int)(Width / (MaxValue - MinValue + 1)));
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            GUI.FillRectangle(sb, Bounds, BackColor);
            // GUI.DrawLine(sb, new Point(X + Width / 2, Y), new Point(X + Width / 2, Y + Height), 1f, Color.Red);
            switch (DrawMode)
            {
                case SliderBarDrawMode.Default:
                    GUI.FillRectangle(sb, new Rectangle(_sliderBound.X, _sliderBound.Y - 5, _sliderBound.Width, _sliderBound.Height + 10), SliderColor);
                    break;
                case SliderBarDrawMode.Material:
                    GUI.FillRectangle(sb, new Rectangle(_sliderBound.X + 1, _sliderBound.Y + 1, _sliderBound.Width - 2, _sliderBound.Height - 2), SliderColor);
                    break;
            }
        }

        public override void HandleEvent()
        {
            base.HandleEvent();

            _sliderBound = new Rectangle(X + (int)((Width - _sliderWidth) / (MaxValue - MinValue) * Value), Y, _sliderWidth, Height);
            var pos = Scene.CurrentScene.MousePosition;

            if (Scene.CurrentScene.IsLeftMouseDown)
            {
                if (_sliderBound.Contains(pos))
                {
                    _isDragging = true;
                    _dx = pos.X - _sliderBound.X;
                }
                else if (Bounds.Contains(pos))
                {
                    Value += (MaxValue - MinValue) * (MoveRatio) * (pos.X < _sliderBound.X ? -1 : 1);
                }
            }
            if (_isDragging)
            {
                Value = (pos.X - X - _dx) * (MaxValue - MinValue) / (Width - _sliderWidth);

                if (Scene.CurrentScene.IsLeftMouseUp)
                    _isDragging = false;
            }
        }
    }
}
