using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix
{
    class Animator
    {
        private const int Delay = 200;

        private Random random = new Random();

        private IKeyboard instance = Keyboard.Instance;

        public async void Start()
        {
            var gradations = Enumerable
                .Range(1, KeyDefinitions.Rows)
                .Select(it =>
                {
                    var keys = KeyDefinitions.GetKeyDefinition(it);
                    return Enumerable
                        .Range(0, keys.Length)
                        .Select(_ => Gradation.Empty)
                        .ToArray();
                })
                .ToArray();

            while (true)
            {
                for (var i = 0; i < KeyDefinitions.Rows; i++)
                {
                    var keys = KeyDefinitions.GetKeyDefinition(i + 1);
                    var gradation = gradations[i];
                    Draw(keys, gradation);
                    gradations[i] = Next(gradation);
                }

                await Task.Delay(Delay);
            }
        }

        private void Draw(Key[] keys, Gradation[] grads)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                var grad = grads[i];
                instance.SetKey(key, grad.Color);
            }
        }

        private Gradation[] Next(Gradation[] arr)
        {
            var newArr = new Gradation[arr.Length];
            Array.Copy(arr, 0, newArr, 1, arr.Length - 1);
            newArr[0] = GetNextColor(arr);
            return newArr;
        }

        private Gradation GetNextColor(Gradation[] grads)
        {
            var first = grads[0].Clone();
            if (first.BaseColor == Color.White)
            {
                if (first.Opacity <= 0.4f)
                {
                    return Gradation.Green;
                }
                first.FadeOut();
                return first;
            }
            if (first.BaseColor == Color.Green)
            {
                if (first.Opacity <= 0.0f)
                {
                    return Gradation.Empty;
                }
                if (first.Opacity < 1.0f || random.Next(3) == 0)
                {
                    first.FadeOut();
                }
                return first;
            }

            if (first.IsClear && grads[1].IsClear && grads[2].IsClear)
            {
                return random.Next(4) == 0 ? Gradation.Empty : Gradation.White;
            }

            return Gradation.Empty;
        }
    }
}
