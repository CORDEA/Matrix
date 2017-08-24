using Corale.Colore.Core;

namespace Matrix
{
    class Gradation
    {
        public static Gradation Green =>
            new Gradation(Color.Green, 1.0f);

        public static Gradation White =>
            new Gradation(Color.White, 1.0f);

        public static Gradation Empty =>
            new Gradation();

        public Color Color =>
            new Color(
                (byte) (BaseColor.R * Opacity),
                (byte) (BaseColor.G * Opacity),
                (byte) (BaseColor.B * Opacity));

        public bool IsClear =>
            BaseColor == Color.Black;

        public Color BaseColor { get; private set; }

        public float Opacity { get; private set; }

        public Gradation()
        {
            BaseColor = Color.Black;
            Opacity = 0.0f;
        }

        public Gradation(Color baseColor, float opacity)
        {
            BaseColor = baseColor;
            Opacity = opacity;
        }

        public Gradation Clone()
        {
            return new Gradation(BaseColor, Opacity);
        }

        public void FadeOut()
        {
            Opacity -= 0.3f;
            if (Opacity < 0.0f)
            {
                Opacity = 0.0f;
            }
        }
    }
}
